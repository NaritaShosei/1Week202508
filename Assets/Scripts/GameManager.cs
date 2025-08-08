using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreData _data;
    private void Start()
    {
        _data = (ScoreData)Resources.Load("ScoreData");
    }

    public void SetScore(Data data)
    {
        _data.Datas.Add(data);
    }
}
