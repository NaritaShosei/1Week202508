using DG.Tweening;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    [SerializeField] private SlideType _slideType;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Vector3 _targetPos = Vector3.zero;

    public bool CanSlide(SlideType type)
    {
        if (type == _slideType)
        {
            transform.DOMove(transform.position + _targetPos, _duration)
                .OnComplete(() => Destroy(gameObject))
                .SetLink(gameObject);
            return true;
        }
        return false;
    }
}
public enum SlideType
{
    Right,
    Left,
    Up,
    Down,
}