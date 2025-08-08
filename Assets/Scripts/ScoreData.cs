using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    public List<Data> Datas = new List<Data>();
}

[System.Serializable]
public class Data
{
    public int Score;
    public string Name;
}