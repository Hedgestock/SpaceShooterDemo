using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int Score = 200;

    void OnDestroy()
    {
        GameObject.Find("ScoreCounter").GetComponent<Score>().AddScore(Score);
    }
}
