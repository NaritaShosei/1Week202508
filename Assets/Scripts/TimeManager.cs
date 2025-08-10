using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    private float _timer;
    public event Action OnTimeOverEvent;
    public bool IsStat { get; private set; }
    [SerializeField] private TimerView _timerView;
    public async UniTask TimerUpdate()
    {
        try
        {
            _timer = _maxTime;
            IsStat = true;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _timerView.ViewUpdate(Mathf.Abs(1 - (_timer / _maxTime)));
                await UniTask.Yield(cancellationToken: destroyCancellationToken);
            }
            Debug.Log("Time Out");
            OnTimeOverEvent?.Invoke();
            IsStat = false;
        }
        catch { }
    }
}
