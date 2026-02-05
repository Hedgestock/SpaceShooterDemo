using UnityEngine;

public class LifePlayerToHUDRelay : MonoBehaviour
{
    Life life;
    TrackLife lifeTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = GetComponent<Life>();
        lifeTracker = GameObject.Find("LifeSlider"). GetComponent<TrackLife>();
        life.LifeChanged.AddListener(lifeTracker.UpdateLife);
        lifeTracker.SetMaxLife(life.LifePoints);
    }
}
