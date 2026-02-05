using UnityEngine;
using UnityEngine.UI;

public class TrackLife : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        //TBH I just was too lazy to setup an event system for such a small demo project so we'll tack life every frame
        GameObject ship = GameObject.FindGameObjectWithTag("Player");
        slider.value = ship.GetComponent<Life>().LifePoints;
    }
}
