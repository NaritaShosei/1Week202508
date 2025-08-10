using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreData Data;
    private static string _name;

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
        Data = SaveLoadService.Load<ScoreData>();
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void AddScore(int score)
    {
        var data = new Data() { Score = score, Name = _name };
        Data.Datas.Add(data);
        SaveLoadService.Save(Data);
    }
}
