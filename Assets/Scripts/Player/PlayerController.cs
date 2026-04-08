using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const string IsRun = "IsRun";

    [SerializeField] GroundDetector _groundDetector;
    [SerializeField] InputReader _inputReader;
    [SerializeField] Mover _mover;
    [SerializeField] Rotator _rotator;
    [SerializeField] Animator _animator;    

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _rotator.Rotate(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
            _animator.SetBool(IsRun, true);
        }
        else
            _animator.SetBool(IsRun, false);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }            
    }
}