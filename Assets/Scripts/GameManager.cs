using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreData _data;
    string _name;
    private void Start()
    {
        _data = (ScoreData)Resources.Load("ScoreData");
    }

    public void AddScore(int score)
    {
        var data = new Data() { Score = score, Name = _name };
        _data.Datas.Add(data);
    }
}
