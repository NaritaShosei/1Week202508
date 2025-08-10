using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private SlideDoor[] _doors;
    private SlideDoor _currentDoor;
    [SerializeField] private TimeManager _timeManager;
    private GameManager _gameManager;
    private int _slideCount;
    [SerializeField] private Text _countText;
    [SerializeField] private FadeUI _fadeUI;
    [SerializeField] private string _bgmName;
    [SerializeField] private string _seName;
    [SerializeField] private ResultPanel _resultPanel;

    private async void Start()
    {
        _gameManager = GameManager.Instance;

        if (!_gameManager.AudioManager.IsBGMPlaying())
        {
            _gameManager.AudioManager.PlayBGM(_bgmName);
        }

        _currentDoor = Instantiate(_doors[Random.Range(0, _doors.Length)]);
        _timeManager.OnTimeOverEvent += AddScore;

        bool isFaded = false;
        _fadeUI.Fade(0, () => isFaded = true);
        await UniTask.WaitUntil(() => isFaded, cancellationToken: destroyCancellationToken);

        await _timeManager.TimerUpdate();

        _resultPanel.FadePanel();
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
            _countText.text = $"Score:{_slideCount}";
            _gameManager.AudioManager.PlaySE(_seName);
        }
    }

    public void LoadScene(string name)
    {
        _fadeUI.Fade(1, () => SceneChanger.SceneChange(name));
    }
}
