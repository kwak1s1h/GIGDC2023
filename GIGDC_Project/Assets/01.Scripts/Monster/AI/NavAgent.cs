using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(LineRenderer))]
public class NavAgent : MonoBehaviour
{
    private PriorityQueue<Node> _openList;
    private List<Node> _closeList;

    private List<Vector3Int> _routePath;

    public float Speed;
    public bool cornerCheck = false;
    private bool _isMove = false;
    private int _moveIdx = 0;
    private Vector3 _nextPos;

    private Vector3Int _currentPosition;
    private Vector3Int _destination;
    public Vector3Int Destination 
    {
        get => _destination; 
        set
        {
            SetCurrentPosition();
            _destination = value;
            CalcRoute();
            _moveIdx = 0;
            if(_isDebug) PrintRoute();
        }
    }

    public bool CanMovePath => _routePath.Count > _moveIdx;

    private LineRenderer _lineRenderer;
    [SerializeField] private bool _isDebug = false;

    private void Awake()
    {
        _openList = new PriorityQueue<Node>();
        _closeList = new List<Node>();
        _routePath = new List<Vector3Int>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        SetCurrentPosition();
        transform.position = MapManager.Instance.GetWorldPos(_currentPosition);
    }

    private void SetCurrentPosition()
    {
        Vector3Int cellPos = MapManager.Instance.GetTilePos(transform.position);
        _currentPosition = cellPos;
    }

    public Vector3Int GetNextTarget()
    {
        if(_moveIdx >= _routePath.Count)
        {
            return Vector3Int.zero;
        }

        return _routePath[_moveIdx++];
    }

    private void Update()
    {
        if (_isMove)
        {
            Vector3 dir = _nextPos - transform.position;
            transform.position += dir.normalized * Speed * Time.deltaTime;
            if (dir.magnitude < 0.1f)
            {
                SetNextTarget();
            }
        }
    }

    private void SetNextTarget()
    {
        if(_moveIdx >= _routePath.Count)
        {
            _isMove = false;
            return;
        }

        _currentPosition = _routePath[_moveIdx];
        _nextPos = MapManager.Instance.GetWorldPos(_currentPosition);
        _moveIdx++;
    }

    // 계산한 경로를 디버그로 찍어본다
    private void PrintRoute()
    {
        _lineRenderer.positionCount = _routePath.Count;
        for(int i = 0; i < _routePath.Count; i++)
        {
            Vector3 worldPos = MapManager.Instance.GetWorldPos(_routePath[i]);
            _lineRenderer.SetPosition(i, worldPos);
        }
    }

    #region Astar

    private bool CalcRoute()
    {
        _openList.Clear();
        _closeList.Clear();

        _openList.Push(
            new Node
            { 
                pos = _currentPosition, 
                _parent = null, 
                G = 0, 
                F = CalcH(_currentPosition) 
            }
        );

        bool result = false;
        int cnt = 0;
        while(_openList.Count > 0)
        {
            Node n = _openList.Pop();
            FindOpenList(n);
            _closeList.Add(n);
            if(n.pos == Destination)
            {
                result = true;
                break;
            }

            cnt++;
            if(cnt >= 10000)
            {
                Debug.Log("While Loop 너무 많이 돌려서 빠갬");
                break;
            }
        }

        if(result)
        {
            _routePath.Clear();
            Node last = _closeList[_closeList.Count - 1];
            while(last._parent != null)
            {
                _routePath.Add(last.pos);
                last = last._parent;
            }
            _routePath.Reverse();
        }

        return result;
    }

    private void FindOpenList(Node n)
    {
        for(int y = -1; y <= 1; y++)
        {
            for(int x = -1; x <= 1; x++)
            {
                if(x == 0 && y == 0) continue;

                Vector3Int nextPos = n.pos + new Vector3Int(x, y, 0);

                Node temp = _closeList.Find(x => x.pos == nextPos);
                if(temp != null) continue;

                // 타일에서 진짜 갈 수 있는 곳인지
                if(MapManager.Instance.CanMove(nextPos) && CheckCorner(n.pos, new Vector3Int(x, y, 0)))
                {
                    float g = (n.pos - nextPos).magnitude + n.G;

                    Node nextOpenNode = new Node {
                        pos = nextPos,
                        _parent = n,
                        G = g,
                        F = g + CalcH(nextPos)
                    };

                    Node exist = _openList.Contains(nextOpenNode);

                    if(exist != null)
                    {
                        if(nextOpenNode.G < exist.G)
                        {
                            exist.G = nextOpenNode.G;
                            exist.G = nextOpenNode.F;
                            exist._parent = nextOpenNode._parent;
                        }
                    }
                    else 
                    {
                        _openList.Push(nextOpenNode);
                    }
                }
            }
        }
    }

    private bool CheckCorner(Vector3Int now, Vector3Int dir)
    {
        if(!cornerCheck) return true;

        Vector3Int[] obstacles = { 
            now + new Vector3Int(dir.x, 0, 0), 
            now + new Vector3Int(0, dir.y, 0) 
        };
        for(int i = 0; i < obstacles.Length; i++) 
        {
            if(!MapManager.Instance.CanMove(obstacles[i]))
                return false;
        }
        return true;
    }

    private float CalcH(Vector3Int pos)
    {
        Vector3Int distance = Destination - pos;
        return distance.magnitude;
    }

    #endregion
}
