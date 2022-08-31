using System.Collections;
using UnityEngine;

public class CoruntineMove : MovableObject
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAlive = true;
            _currentState = State.MOVE;
            StartCoroutine(Alive());
        }
    }

    private IEnumerator Alive()
    {
        while (_isAlive)
        {
            switch (_currentState)
            {
                case State.MOVE:
                    MoveForward();
                    if (Vector3.Distance(_transform.position, _endPosition) <= 0.1)
                    {
                        _currentState = State.JUMP;
                    }
                    break;
                
                case State.JUMP:
                    Jump();
                    Rotate(new Vector3(0, 90, 0));
                    if (_transform.position.y - jumpHeight >= 0)
                    {
                        _currentState = State.FALL;
                    }
                    break;
                
                case State.FALL:
                    Fall();
                    Rotate(new Vector3(0, 180, 0));
                    if (_transform.position.y <= 0)
                    {
                        _currentState = State.MOVE_BACK;
                    }
                    break;
                
                case State.MOVE_BACK:
                    MoveForward();
                    if (Vector3.Distance(_transform.position, _startPoint) <= 0.1)
                    {
                        _isAlive = false;
                        print("Coruntine move completed");
                    }
                    break;
            }
            yield return null;
        }
    }

}
