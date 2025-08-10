using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    private float _timer;
    public event Action OnTimeOverEvent;

    public async UniTask Timer()
    {
        try
        {
            _timer = _maxTime;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                await UniTask.Yield(cancellationToken: destroyCancellationToken);
            }
            Debug.Log("Time Out");
            OnTimeOverEvent?.Invoke();
        }
        catch { }
    }
}
