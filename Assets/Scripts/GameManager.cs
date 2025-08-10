using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    ScoreData _data;
    string _name;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _data = SaveLoadService.Load<ScoreData>();
    }

    public void AddScore(int score)
    {
        var data = new Data() { Score = score, Name = _name };
        _data.Datas.Add(data);
        SaveLoadService.Save(_data);
    }
}
