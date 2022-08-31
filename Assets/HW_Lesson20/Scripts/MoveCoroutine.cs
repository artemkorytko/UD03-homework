using System.Collections;
using UnityEngine;
public class MoveCoroutine : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Transform capsule;
    [SerializeField] private float speed;
    private Transform _targetPoint;
    private int _currentPoint;
    private void Start()
    {
        _currentPoint = 0;
        _targetPoint = points[_currentPoint];
        StartCoroutine(CoroutineMove());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(CoroutineMove());
        }
    }
    private IEnumerator CoroutineMove()
    {
        if(capsule.position == _targetPoint.position)
        {
            _currentPoint ++;
            if (_currentPoint >= points.Length)
                _currentPoint = 0;
            if (_currentPoint==2)
            {
                capsule.rotation = Quaternion.Euler(0, 180, 0);
               
            }
            if (_currentPoint==0)
            {
                speed = 0;
                yield return new WaitForSeconds(1);
                Debug.Log("Finish Coroutine Message");
            }
            _targetPoint = points[_currentPoint];
        }
        capsule.position = Vector3.MoveTowards(capsule.position, _targetPoint.position, speed * Time.deltaTime);
        yield return null;
    }
}
