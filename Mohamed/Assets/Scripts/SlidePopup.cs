using DG.Tweening;
using UnityEngine;

public class SlidePopup : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private float showY = 0f;      // on-screen Y
    [SerializeField] private float hideY = -800f;   // off-screen Y
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private Ease showEase = Ease.OutBack;
    [SerializeField] private Ease hideEase = Ease.InBack;

    private RectTransform _rect;
    private Tween _tween;
    private bool IsVisible;


    private void Awake()
    {
        _rect = (RectTransform)transform;

        // start hidden
        var pos = _rect.anchoredPosition;
        _rect.anchoredPosition = new Vector2(pos.x, hideY);
        gameObject.SetActive(false);
        IsVisible = false;
    }

    public void Show()
    {
        if (IsVisible) return;

        IsVisible = true;
        gameObject.SetActive(true);

        _tween?.Kill();
        _tween = _rect.DOAnchorPosY(showY, duration)
                      .SetEase(showEase);
    }

    public void Hide()
    {
        if (!IsVisible) return;

        IsVisible = false;

        _tween?.Kill();
        _tween = _rect.DOAnchorPosY(hideY, duration)
                      .SetEase(hideEase)
                      .OnComplete(() => gameObject.SetActive(false));
    }

    private void OnDestroy()
    {
        _tween?.Kill();
    }
}
