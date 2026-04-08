using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _angle;

    public void Rotate(float direction)
    {
        if (direction > 0)
            _angle = 0;
        else
            _angle = 180;

        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }
}