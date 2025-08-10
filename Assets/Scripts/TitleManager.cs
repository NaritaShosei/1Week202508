using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private RankingText[] _rankingTexts;

    private void Start()
    {
        var datas = GameManager.Instance.Data.Datas.OrderByDescending(x => x.Score).ToList();

        for (int i = 0; i < _rankingTexts.Length; i++)
        {
            if (datas.Count < i) { break; }
            _rankingTexts[i].NameText.text =
                datas[i].Name != "" || datas[i].Name != null ? datas[i].Name : "NoName";

            _rankingTexts[i].ScoreText.text = $"{datas[i].Score}";
        }
    }
}
[System.Serializable]
public class RankingText
{
    public Text NameText;
    public Text ScoreText;
}