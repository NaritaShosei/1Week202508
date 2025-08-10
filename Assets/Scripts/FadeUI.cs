using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Image _image;

    public void Fade(float target, Action onComplete = null)
    {
        _image.DOFade(target, _duration).SetLink(gameObject).OnComplete(() => onComplete?.Invoke());
    }
}
