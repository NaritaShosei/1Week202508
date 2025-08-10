using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Image _view;

    public void ViewUpdate(float amount)
    {
        _view.fillAmount = amount;
    }
}
