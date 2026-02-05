using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TrackLife : MonoBehaviour
{
    Sequence sliderTween = null;
    Slider slider;
    RectTransform sliderTransform;
    private void Start()
    {
        slider = GetComponent<Slider>();
        sliderTransform = GetComponent<RectTransform>();
    }

    public void SetMaxLife(int lp)
    {
        slider.maxValue = lp;
        UpdateLife(lp);
    }
    public void UpdateLife(int lp)
    {
        if (slider.value != lp)
        {
            DOTween.Kill(sliderTween);
            sliderTween = DOTween.Sequence();
            sliderTween.Append(DOTween.To(() => slider.value, x => slider.value = x, lp, .2f));

            sliderTween.Join(sliderTransform.DOScaleY(Math.Max(5, 2 + Math.Abs(slider.value - lp) / 2), .1f).SetEase(Ease.OutElastic));
            sliderTween.Append(sliderTransform.DOScaleY(2, .1f).SetEase(Ease.InBounce));
        }
    }
}
