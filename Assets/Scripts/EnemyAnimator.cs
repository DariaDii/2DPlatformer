using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public const string IsWalk = "IsWalk";

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Patrolling += UpdateWalkAnimation;
    }

    private void OnDisable()
    {
        _enemy.Patrolling -= UpdateWalkAnimation;
    }

    public void UpdateWalkAnimation(bool isWalking)
    {

        _animator.SetBool(IsWalk, isWalking);
    }
}
