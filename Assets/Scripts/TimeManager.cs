using Cysharp.Threading.Tasks;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    private float _timer;

    private async void Start()
    {
        await Timer();
    }

    private async UniTask Timer()
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
        }
        catch { }
    }
}
