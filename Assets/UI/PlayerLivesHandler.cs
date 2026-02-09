using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesHandler : MonoBehaviour
{

    public GameObject StartText;
    public GameObject PlayerShip;

    public Image GameOverText;

    public TextMeshProUGUI LivesText;
    private int _lives = 3;
    private int Lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (value <= 0)
                GameOver();
            LivesText.text = $"<sprite=\"Number_font (8 x 8)\" index={value}>";
        }
    }

    void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(PlayerShip);
    }

    public void LoseLife()
    {
        Lives--;
        Invoke(nameof(SpawnPlayer), 1);
    }

    void GameOver()
    {
        GameObject.Find("Grid").GetComponent<GameSpeedController>().IsRunning = false;
        GameObject.Find("Spawner").GetComponent<Spawner>().Spawning = false;
        var HUDOff = GameObject.Find("Canvas").GetComponent<HUDTweenerTropFort>().Off();
        HUDOff.AppendCallback(() => Lives = 3);

        Sequence whyNot = DOTween.Sequence();
        whyNot.Append(GameOverText.rectTransform.DOAnchorMin(new(.5f, .5f), 1));
        whyNot.Join(GameOverText.rectTransform.DOAnchorMax(new(.5f, .5f), 1));
        whyNot.AppendInterval(.5f);
        whyNot.AppendCallback(() => Instantiate(StartText));
        whyNot.Append(GameOverText.rectTransform.DOAnchorMin(new(.5f, -.1f), 1));
        whyNot.Join(GameOverText.rectTransform.DOAnchorMax(new(.5f, -.1f), 1));
        whyNot.AppendCallback(() => GameOverText.rectTransform.anchorMin = GameOverText.rectTransform.anchorMax = new(.5f, 1));
    }
}
