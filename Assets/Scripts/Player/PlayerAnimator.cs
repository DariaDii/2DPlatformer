using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public const string IsRun = "IsRun";

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Animator _animator;

    private const float moveThreshold = 0.01f;    

    private void OnEnable()
    {
        _inputReader.Moving += UpdateRunAnimation;
    }

    private void OnDisable()
    {
        _inputReader.Moving -= UpdateRunAnimation;
    }

    private void UpdateRunAnimation(float direction)
    {
        bool isRunning = Mathf.Abs(direction) > moveThreshold;
        _animator.SetBool(IsRun,isRunning);
    }    
}