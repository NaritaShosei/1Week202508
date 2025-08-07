using UnityEngine;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private SlideDoor[] _doors;
    private SlideDoor _currentDoor;

    private void Start()
    {
        _currentDoor = Instantiate(_doors[Random.Range(0, _doors.Length)]);
    }

    public void Flick(SlideType type)
    {
        Debug.Log(type.ToString());
        if (_currentDoor.CanSlide(type))
        {
            Destroy(_currentDoor.gameObject);
            _currentDoor = Instantiate(_doors[Random.Range(0, _doors.Length)]);
        }
    }
}
