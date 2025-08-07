using UnityEngine;

[System.Serializable]
public class SlideDoor
{
    [SerializeField] private SlideType _slideType;

    public bool CanSlide(SlideType type)
    {
        return _slideType == type;
    }
}
public enum SlideType
{
    Right,
    Left,
    Up,
    Down,
}