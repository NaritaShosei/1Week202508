using DG.Tweening;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private float _duration = 0.5f;

    private void Awake()
    {
        if (_group != null)
        {
            _group = GetComponent<CanvasGroup>();
        }
        _group.blocksRaycasts = false;
    }

    public void FadePanel()
    {
        if (_group == null) return;
        _group.blocksRaycasts = true;
        _group.DOFade(1, _duration).SetLink(gameObject);
    }
}
