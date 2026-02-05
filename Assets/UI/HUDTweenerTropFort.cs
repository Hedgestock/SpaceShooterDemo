using UnityEngine;
using DG.Tweening;

public class HUDTweenerTropFort : MonoBehaviour
{
    public RectTransform Bars;
    public RectTransform ItemHolder;
    public RectTransform PWR;
    public RectTransform LifeIcon;
    public RectTransform LifeCounter;

    public Sequence On()
    {
        Sequence HUDOn = DOTween.Sequence();
        HUDOn.Join(Bars.DOAnchorPos(new(16, -16), 1));
        HUDOn.Join(ItemHolder.DOAnchorPos(new(-16, -16), 1));
        HUDOn.Join(PWR.DOAnchorPos(new(-17, -48), 1));
        HUDOn.Join(LifeIcon.DOAnchorPos(new(-16, 16), 1));
        HUDOn.Join(LifeCounter.DOAnchorPos(new(-35, 18), 1));
        return HUDOn;
    }

    public Sequence Off()
    {
        Sequence HUDOff = DOTween.Sequence();
        HUDOff.Join(Bars.DOAnchorPos(new(-70, -16), 1));
        HUDOff.Join(ItemHolder.DOAnchorPos(new(-16, 40), 1));
        HUDOff.Join(PWR.DOAnchorPos(new(40, -48), 1));
        HUDOff.Join(LifeIcon.DOAnchorPos(new(40, 16), 1));
        HUDOff.Join(LifeCounter.DOAnchorPos(new(-35, -35), 1));
        return HUDOff;
    }
}
