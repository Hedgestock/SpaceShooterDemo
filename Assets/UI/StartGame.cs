using UnityEngine;
using DG.Tweening;

public class StartGame : MonoBehaviour
{

    void Start()
    {
        transform.position = Vector3.up * (Camera.main.orthographicSize + 1);
        transform.DOMove(Vector3.up * 2, 1).SetEase(Ease.OutBack);
        GameObject.Find("ScoreCounter").GetComponent<Score>().ResetScore();
    }

    void OnDestroy()
    {
        GameObject.Find("Grid").GetComponent<GameSpeedController>().IsRunning = true;
        GameObject.Find("Spawner").GetComponent<Spawner>().Spawning = true;
        GameObject.Find("Canvas").GetComponent<HUDTweenerTropFort>().On();
    }
}
