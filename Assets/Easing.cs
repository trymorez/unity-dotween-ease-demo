using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Easing : MonoBehaviour
{
    public Image circle, circleOutline;
    public Slider slider;
    [SerializeField] float easeTime = 1.5f;
    float HalfEaseTime;
    Ease ease = Ease.Linear;

    void Start()
    {
        Sequence sequenceCircle;
        Sequence sequenceSlider;
        HalfEaseTime = easeTime * 0.5f;

        //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear).Pause();
        circleOutline.DOFillAmount(0, easeTime).SetEase(ease).SetLoops(-1, LoopType.Yoyo)
        .OnStepComplete(() =>
        {
            circleOutline.fillClockwise = !circleOutline.fillClockwise;
            //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
        })
        .Pause();

        sequenceCircle = DOTween.Sequence();
        sequenceCircle.Append(circle.transform.DOScale(Vector3.zero, HalfEaseTime).SetEase(ease));
        //sequenceCircle.Append(circle.transform.DOScale(Vector3.one * 0.5f, HalfEaseTime));
        sequenceCircle.SetLoops(-1, LoopType.Yoyo);
        sequenceCircle.OnComplete(() =>
        {
            //circle.fillClockwise = !circle.fillClockwise;
            //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
        })
        .Pause();

        sequenceSlider = DOTween.Sequence();
        sequenceSlider.Append(slider.DOValue(1f, HalfEaseTime).SetEase(ease));
        //sequenceSlider.Append(slider.DOValue(0f, HalfEaseTime));
        sequenceSlider.SetLoops(-1, LoopType.Yoyo);
        sequenceSlider.OnComplete(() =>
        {
            //circle.fillClockwise = !circle.fillClockwise;
            //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
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
