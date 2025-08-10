using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public List<Data> Datas = new List<Data>();
}

[System.Serializable]
public class Data
{
    public int Score;
    public string Name;
}