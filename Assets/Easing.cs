using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Easing : MonoBehaviour
{
    public Image circle, circleOutline;
    public Slider slider;
    public Ease ease = Ease.Linear;
    [SerializeField] TMP_Dropdown EaseOption;
    [SerializeField] float easeTime = 1.5f;
    float HalfEaseTime;

    void Start()
    {
        Sequence sequenceCircle;
        Sequence sequenceSlider;
        HalfEaseTime = easeTime * 0.5f;
        ease = (Ease) EaseOption.value + 1;

        // circle filling
        circleOutline.DOFillAmount(0, easeTime).SetEase(ease).SetLoops(-1, LoopType.Yoyo)
        .OnStepComplete(() =>
        {
            circleOutline.fillClockwise = !circleOutline.fillClockwise;
        })
        .Pause();

        // circle radial scale
        sequenceCircle = DOTween.Sequence();
        sequenceCircle.Append(circle.transform.DOScale(Vector3.zero, HalfEaseTime).SetEase(ease));
        sequenceCircle.SetLoops(-1, LoopType.Yoyo);
        sequenceCircle.OnComplete(() =>
        {
        })
        .Pause();

        // slider tweening
        sequenceSlider = DOTween.Sequence();
        sequenceSlider.Append(slider.DOValue(1f, HalfEaseTime).SetEase(ease));
        sequenceSlider.SetLoops(-1, LoopType.Yoyo);
        sequenceSlider.OnComplete(() =>
        {
        })
        .Pause();

        StartTweens();
    }

    public void StartTweens()
    {
        DOTween.PlayAll();
    }

    void Update()
    {
        
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
