using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    private float _timer;
    public event Action OnTimeOverEvent;
    public bool IsStat { get; private set; }
    public async UniTask Timer()
    {
        try
        {
            _timer = _maxTime;
            IsStat = true;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                await UniTask.Yield(cancellationToken: destroyCancellationToken);
            }
            Debug.Log("Time Out");
            OnTimeOverEvent?.Invoke();
            IsStat = false;
        }
        catch { }
    }
}
