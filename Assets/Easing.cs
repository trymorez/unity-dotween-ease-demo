using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Easing : MonoBehaviour
{
    public Image circle, circleOutline;
    public Slider slider;
    [SerializeField] float easeTime = 1.5f;

    void Start()
    {
        Sequence sequenceCircle;
        Sequence sequenceSlider;

        //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear).Pause();
        circleOutline.DOFillAmount(0, easeTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)
        .OnStepComplete(() =>
        {
            circleOutline.fillClockwise = !circleOutline.fillClockwise;
            //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
        })
        .Pause();

        sequenceCircle = DOTween.Sequence();
        sequenceCircle.Append(circle.transform.DOScale(Vector3.zero, easeTime * 0.5f));
        sequenceCircle.Append(circle.transform.DOScale(Vector3.one * 0.5f, easeTime * 0.5f));
        sequenceCircle.SetLoops(-1, LoopType.Restart);
        sequenceCircle.OnComplete(() =>
        {
            //circle.fillClockwise = !circle.fillClockwise;
            //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
        })
        .Pause();

        sequenceSlider = DOTween.Sequence();
        sequenceSlider.Append(slider.DOValue(1f, easeTime * 0.5f));
        sequenceSlider.Append(slider.DOValue(0f, easeTime * 0.5f));
        sequenceSlider.SetLoops(-1, LoopType.Restart);
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
