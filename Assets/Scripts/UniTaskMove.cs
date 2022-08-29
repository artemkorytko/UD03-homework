using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTaskMove : MovableObject
{
    private CancellationToken _cancellationToken;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAlive = true;
            _currentState = State.MOVE;
            Alive();
        }
    }

    private async UniTask Alive()
    {
        while (_isAlive)
        {
            if (_currentState.Equals(State.MOVE))
            {
                MoveForward();
                if (Vector3.Distance(_transform.position, _endPosition) <= 0.1)
                {
                    _currentState = State.JUMP;
                }
            }

            if (_currentState.Equals(State.JUMP))
            {
                Jump();
                Rotate(new Vector3(0, 90, 0));
                if (_transform.position.y - jumpHeight >= 0)
                {
                    _currentState = State.FALL;
                }
            }

            if (_currentState.Equals(State.FALL))
            {
                Fall();
                Rotate(new Vector3(0, 180, 0));
                if (_transform.position.y <= 0)
                {
                    _currentState = State.MOVE_BACK;
                }
            }

            if (_currentState.Equals(State.MOVE_BACK))
            {
                MoveForward();
                if (Vector3.Distance(_transform.position, _startPoint) <= 0.1)
                {
                    _isAlive = false;
                    print("UniTask move completed");
                }
            }
            await UniTask.Yield();
        }
    }
}
