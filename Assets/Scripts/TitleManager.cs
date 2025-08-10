using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private RankingText[] _rankingTexts;
    [SerializeField] private Text _nameText;
    [SerializeField] private int _maxNameLength = 7;
    [SerializeField] private FadeUI _fadeUI;
    [SerializeField] private string _bgmName = "IngameBGM";
    private void Start()
    {
        if (!GameManager.Instance.AudioManager.IsBGMPlaying())
        {
            GameManager.Instance.AudioManager.PlayBGM(_bgmName);
        }

        _fadeUI.Fade(0);
        var datas = GameManager.Instance.Data.Datas.OrderByDescending(x => x.Score).ToList();

        for (int i = 0; i < _rankingTexts.Length; i++)
        {
            if (datas.Count <= i) { break; }
            _rankingTexts[i].NameText.text =
                  !string.IsNullOrEmpty(datas[i].Name) ? datas[i].Name : "NoName";

            _rankingTexts[i].ScoreText.text = $"{datas[i].Score}";
        }
    }

    public void LoadScene(string name)
    {
        if (_nameText.text.Length >= _maxNameLength)
        {
            Debug.Log("Name Is Long Aho");
            return;
        }

        GameManager.Instance.SetName(_nameText.text);
        _fadeUI.Fade(1, () => SceneChanger.SceneChange(name));
    }
}
[System.Serializable]
public class RankingText
{
    public Text NameText;
    public Text ScoreText;
}