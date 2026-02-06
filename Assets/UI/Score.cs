using DG.Tweening;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int _score = 0;
    private int ScorePoints
    {
        get { return _score; }
        set
        {
            _score = value;
            if (value == 0)
            {
                ScoreText.text = "<sprite=\"Number_font (8 x 8)\" index=0>";
                return;
            }
            ScoreText.text = "";
            for (int i = 1; i <= _score; i *= 10)
            {
                // DO NOT LOOK AT WHAT IS HAPPENING HERE. THIS IS TOTTALY PERFORMANT WINKWINK
                // Couldn't figure out how to make sprite assets override unicode...
                int digit = ((int)(value / i)) % 10;
                ScoreText.text = $"<sprite=\"Number_font (8 x 8)\" index={digit}>" + ScoreText.text;
            }
        }
    }

    int scoreToTween = 0;
    Sequence scoreTween = null;

    public void AddScore(int s)
    {
        if (s == 0) return;
        if (scoreTween != null)
        {
            scoreToTween += s;
        }
        else
        {
            scoreTween = DOTween.Sequence();
            //Yeah yeah score can rack up and linear to .5s is not linear to score value but flemme
            scoreTween.Append(DOTween.To(() => ScorePoints, x => ScorePoints = x, ScorePoints + s, .5f).SetEase(Ease.Linear));
            scoreTween.AppendCallback(() => { scoreTween = null; AddScore(scoreToTween); scoreToTween = 0; });
        }
    }

    public void ResetScore()
    {
        DOTween.Kill(scoreTween);
        ScorePoints = 0;
    }
}
