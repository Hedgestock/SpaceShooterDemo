using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HUDTweenerTropFort : MonoBehaviour
{
    public RectTransform Bars;
    public RectTransform ItemHolder;
    public HorizontalLayoutGroup ItemHolderGroup;
    public RectTransform PWR;
    public RectTransform LifeIcon;
    public RectTransform LifeCounter;
    public RectTransform ScoreCounter;

    public Sequence On()
    {
        Sequence HUDOn = DOTween.Sequence();
        HUDOn.Join(Bars.DOAnchorPos(new(16, -16), 1));
        HUDOn.Join(ItemHolder.DOAnchorPos(new(-16, -16), 1));
        HUDOn.Join(PWR.DOAnchorPos(new(-16, -48), 1f));
        HUDOn.Join(LifeIcon.DOAnchorPos(new(-16, 16), 1));
        HUDOn.Join(LifeCounter.DOAnchorPos(new(-35, 18), 1));
        HUDOn.Join(ScoreCounter.DOAnchorPos(new(35, 18), 1));

        HUDOn.Append(DOTween.To(() => ItemHolderGroup.spacing, x => ItemHolderGroup.spacing = x, 0, .5f));
        HUDOn.Join(PWR.DOAnchorPos(new(-32, -48), .5f));


        return HUDOn;
    }

    public Sequence Off()
    {
        Sequence HUDOff = DOTween.Sequence();
        HUDOff.Join(Bars.DOAnchorPos(new(-70, -16), 1));
        HUDOff.Join(DOTween.To(() => ItemHolderGroup.spacing, x => ItemHolderGroup.spacing = x, -32, .5f));
        HUDOff.Join(PWR.DOAnchorPos(new(40, -48), 1));
        HUDOff.Join(LifeIcon.DOAnchorPos(new(40, 16), 1));
        HUDOff.Join(LifeCounter.DOAnchorPos(new(-35, -35), 1));
        HUDOff.Join(ScoreCounter.DOAnchorPos(new(35, -35), 1));
        HUDOff.Join(ItemHolder.DOAnchorPos(new(-16, 40), 1));

        return HUDOff;
    }
}
