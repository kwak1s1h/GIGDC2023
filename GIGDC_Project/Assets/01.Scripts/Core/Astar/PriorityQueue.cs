using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable<T>
{
    public List<T> _heap = new List<T>();

    public int Count => _heap.Count;

    public T Contains(T t)
    {
        int idx = _heap.IndexOf(t);
        if(idx < 0) return default(T);
        return _heap[idx];
    }

    public void Push(T data)
    {
        // 리스트의 맨 끝에 넣는다.
        _heap.Add(data); 
        // 맨 마지막 원소의 인덱스를 알아내서 now에 저장한다.
        int now = _heap.Count - 1;

        // 꼭대기에 있지 않다. 근데 그러다가 내 자리를 찾으면 break 건다.
        while(now > 0)
        {
            // Parent 찾기
            int next = (now - 1) / 2;
            // 다른애의 F가 나의 F보다 작을 때
            if(_heap[now].CompareTo(_heap[next]) < 0)
            {
                break;
            }
            // 다른애의 F가 나의 F보다 클 때
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            
            now = next;
        }
    }

    public T Pop()
    {
        T ret = _heap[0];
        int lastIndex = _heap.Count - 1;
        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);
        lastIndex--;

        int now = 0;

        while(true)
        {
            // Child 찾기
            int left = 2 * now + 1;
            int right = 2 * now + 2;

            int next = now;

            if(left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                next = left;

            if(right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                next = right;

            // 내 자리를 찾았을 때
            if(next == now)
            {
                break;
            }
            
            // 변경해야 된다면 교체
            T temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            
            now = next;
        }

        return ret;
    }

    public T Peek()
    {
        return _heap.Count == 0 ? default(T) : _heap[0];
    }

    public void Clear()
    {
        _heap.Clear();
    }
}
