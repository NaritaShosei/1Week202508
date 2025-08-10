using UnityEngine;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private SlideDoor[] _doors;
    private SlideDoor _currentDoor;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private GameManager _gameManager;
    private int _slideCount;

    private async void Start()
    {
        _currentDoor = Instantiate(_doors[Random.Range(0, _doors.Length)]);
        _timeManager.OnTimeOverEvent += AddScore;
        await _timeManager.Timer();
    }

    private void OnDisable()
    {
        _timeManager.OnTimeOverEvent -= AddScore;
    }

    private void AddScore()
    {
        _gameManager.AddScore(_slideCount);
    }

    public void Flick(SlideType type)
    {
        if (!_timeManager.IsStat) { return; }
        Debug.Log(type.ToString());
        if (_currentDoor.CanSlide(type))
        {
            _currentDoor = Instantiate(_doors[Random.Range(0, _doors.Length)]);
            _slideCount++;
        }
    }
}
