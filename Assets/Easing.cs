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
        Sequence sequence;

        //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear).Pause();
        circleOutline.DOFillAmount(0, easeTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)
            .OnStepComplete(() =>
            {
                circleOutline.fillClockwise = !circleOutline.fillClockwise;
                //circleOutline.DOColor(RandomColor(), easeTime).SetEase(Ease.Linear);
            })
            .Pause();

        sequence = DOTween.Sequence();
        sequence.Append(circle.transform.DOScale(Vector3.zero, easeTime / 2));
        sequence.Append(circle.transform.DOScale(Vector3.one / 2, easeTime / 2));
        sequence.SetLoops(-1, LoopType.Restart);
        sequence.OnComplete(() =>
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
