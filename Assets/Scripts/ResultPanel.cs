using DG.Tweening;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private float _duration = 0.5f;
    public void FadePanel()
    {
        _group.blocksRaycasts = true;
        _group.DOFade(1, _duration).SetLink(gameObject);
    }
}
