using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private Transform _currentPoint;
    private float _distanceToTargetPoint = 0.1f;

    private void Start()
    {
        _currentPoint=_startPoint;
    }

    private void Update()
    {
        Patroll();
    }

    public void Patroll()
    {
        _animator.SetBool("IsWalk",true);
        transform.position = Vector3.MoveTowards(transform.position,_currentPoint.position,_speed*Time.deltaTime);

        Vector3 toTarget = _currentPoint.position - transform.position;
        float distance = toTarget.sqrMagnitude;

        if (distance < _distanceToTargetPoint * _distanceToTargetPoint)
        {
            if (_currentPoint == _startPoint)
                _currentPoint = _endPoint;
            else
                _currentPoint = _startPoint;
        }

        TurnToCurrentPoint();
    }

    private void TurnToCurrentPoint()
    {
        _spriteRenderer.flipX = _currentPoint.position.x > transform.position.x;
    }
}
