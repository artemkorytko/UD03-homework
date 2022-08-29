using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected float jumpHeight ;
    [SerializeField] protected Transform endPoint;

    protected Transform _transform;
    protected State _currentState;
    protected Vector3 _startPoint;
    protected Vector3 _endPosition;
    protected bool _isAlive;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _startPoint = _transform.position;
        _endPosition = endPoint.position;
    }


    protected void MoveForward()
    {
        _transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    protected void Jump()
    {
        _transform.Translate(_transform.up * (moveSpeed * Time.deltaTime));
    }

    protected void Fall()
    {
        _transform.Translate(-_transform.up * (moveSpeed * Time.deltaTime));
    }

    protected void Rotate(Vector3 rotate)
    {
        _transform.rotation =
            Quaternion.RotateTowards(_transform.rotation, Quaternion.Euler(rotate), rotateSpeed * Time.deltaTime);
    }
}
