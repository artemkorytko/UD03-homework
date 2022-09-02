using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
public class MoveUniTask : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Transform capsule;
    [SerializeField] private float speed;
    [SerializeField] private bool isMove;
    private Transform _targetPoint;
    private int _currentPoint;
    
    private void Start()
    {
        _currentPoint = 0;
        _targetPoint = points[_currentPoint];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isMove==false)
            {
                isMove = true;
            }
            else
            {
                isMove = false;
            }
        }
        Move();
    }

    private void Move()
    {
        UniTaskMove();
    }

    private async UniTask UniTaskMove()
    {
        if (isMove)
        {
            if (capsule.position == _targetPoint.position)
            {
                _currentPoint++;
                if (_currentPoint >= points.Length)
                    _currentPoint = 0;
                if (_currentPoint == 2)
                {
                    capsule.rotation = Quaternion.Euler(0, 180, 0);

                }

                if (_currentPoint == 0)
                {
                    speed = 0;
                    await UniTask.Delay(TimeSpan.FromSeconds(1));
                    Debug.Log("Finish Unitask Message");
                }

                _targetPoint = points[_currentPoint];
            }

            capsule.position = Vector3.MoveTowards(capsule.position, _targetPoint.position, speed * Time.deltaTime);
            await UniTask.Yield();
        }
    }
}
