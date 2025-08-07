using UnityEngine;
using UnityEngine.UI;

public class SlideDoor : MonoBehaviour
{
    [SerializeField] private SlideType _slideType;

    public bool CanSlide(SlideType type)
    {
        if (type == _slideType)
        {
            // ドアをスライドするアニメーション
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