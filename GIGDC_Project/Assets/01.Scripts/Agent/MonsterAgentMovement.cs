using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    protected float _currentVelocity = 0f;
    protected Vector2 _movementDirection;
    private bool _useMove = true;

    public float speed = 0;

    protected void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput, bool useMove){

        _useMove = useMove;
        if (useMove == false) return;

        // 우리 게임에 가속도가 필요한가 싶어서 일단 주석 해둠
        //if(movementInput.sqrMagnitude > 0){
        //    if(Vector2.Dot(movementInput, _movementDirection) < 0){ //벡터의 내적 / 이동방향과 입력 방향이 역방향일때
        //        _currentVelocity = 0f;
        //    }
        //    _movementDirection = movementInput.normalized;
        //}
        _movementDirection = movementInput.normalized;
        _currentVelocity = CalcSpeed(movementInput);
    }

    private float CalcSpeed(Vector2 movementInput){
        if(movementInput.sqrMagnitude > 0){
            _currentVelocity = speed;
        }
        else{
            _currentVelocity = 0;
        }
        return _currentVelocity;
    }

    private void FixedUpdate() {
        if (_useMove)
            _rigid.velocity  = _movementDirection * _currentVelocity;
    }

    public void StopImmediatly(){
        _currentVelocity = 0f;
        _rigid.velocity = Vector2.zero;
    }
}
