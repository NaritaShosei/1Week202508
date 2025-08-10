using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FlickInputManager : MonoBehaviour
{
    [SerializeField] InputActionAsset _input;
    [SerializeField] IngameManager _slideManager;
    [SerializeField] float _minFlickDistance = 50f; // 最小フリック距離（スマホ用）

    Vector2 _startPosition;
    Vector2 _currentPosition;
    bool _isUIClick;

    private void Awake()
    {
        _input.FindAction("Crick").started += OnPointerDown;
        _input.FindAction("Crick").canceled += OnPointerUp;
        _input.FindAction("Pointer").performed += OnPointerPosition;
    }

    private void OnDisable()
    {
        _input.FindAction("Crick").started -= OnPointerDown;
        _input.FindAction("Crick").canceled -= OnPointerUp;
        _input.FindAction("Pointer").performed -= OnPointerPosition;
    }

    void OnPointerDown(InputAction.CallbackContext context)
    {
        // スマホ用のUI判定改善
        if (IsPointerOverUI())
        {
            Debug.Log("UI上をタッチしたのでフリック処理はスキップ");
            _isUIClick = true;
            return;
        }

        Debug.Log("DOWN");
        _startPosition = _currentPosition;
        _isUIClick = false;
    }

    // スマホでのUI判定を改善
    bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

#if UNITY_EDITOR
        return EventSystem.current.IsPointerOverGameObject();
#else
        // スマホ用：最初のタッチのみをチェック
        if (Input.touchCount > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        return EventSystem.current.IsPointerOverGameObject();
#endif
    }

    void OnPointerPosition(InputAction.CallbackContext context)
    {
        _currentPosition = context.ReadValue<Vector2>();
    }

    void OnPointerUp(InputAction.CallbackContext context)
    {
        if (_isUIClick)
        {
            Debug.Log("UI上をクリックしていたためフリックは実行されません");
            return;
        }

        Debug.Log("UP");
        Vector2 endPosition = _currentPosition;
        Vector2 flickVector = endPosition - _startPosition;
        float flickDistance = flickVector.magnitude;

        // スマホでは最小フリック距離を設定（誤タッチ防止）
        if (flickDistance < _minFlickDistance)
        {
            Debug.Log($"フリック距離が不足: {flickDistance:F1} < {_minFlickDistance}");
            return;
        }

        // 方向判定を角度ベースで行う（より正確）
        float angle = Mathf.Atan2(flickVector.y, flickVector.x) * Mathf.Rad2Deg;

        // 角度を0-360度に正規化
        if (angle < 0) angle += 360f;

        Debug.Log($"フリック検出: 距離={flickDistance:F1}, 角度={angle:F1}度");

        // 8方向を4方向に分割（各90度ずつ、45度のマージン）
        if (angle >= 315f || angle < 45f)
        {
            // 右方向 (315° - 45°)
            Debug.Log("右フリック");
            _slideManager.Flick(SlideType.Right);
        }
        else if (angle >= 45f && angle < 135f)
        {
            // 上方向 (45° - 135°)
            Debug.Log("上フリック");
            _slideManager.Flick(SlideType.Up);
        }
        else if (angle >= 135f && angle < 225f)
        {
            // 左方向 (135° - 225°)
            Debug.Log("左フリック");
            _slideManager.Flick(SlideType.Left);
        }
        else if (angle >= 225f && angle < 315f)
        {
            // 下方向 (225° - 315°)
            Debug.Log("下フリック");
            _slideManager.Flick(SlideType.Down);
        }
    }
}