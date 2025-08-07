using UnityEngine;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private SlideDoor[] _doors;

    public void Flick(SlideType type)
    {
        Debug.Log(type.ToString());
    }
}
