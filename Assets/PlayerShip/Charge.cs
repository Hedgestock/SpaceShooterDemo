using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{

    bool charging = false;
    bool shooting = false;
    private Slider ChargeBar;

    public void ChargeFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (ChargeBar.value > .93f)
                gameObject.SendMessage("FireCharged");
            else
                gameObject.SendMessage("OnFire");

            ChargeBar.value = 0;

            shooting = charging = true;

            PeriodicShoot();
        }
        if (context.canceled)
        {
            shooting = charging = false;
            CancelInvoke(nameof(PeriodicShoot));
        }
    }

    void PeriodicShoot()
    {
        if (!shooting) return;

        if (ChargeBar.value > .93f)
            gameObject.SendMessage("OnFire");

        Invoke(nameof(PeriodicShoot), .2f);
    }

    void Awake()
    {
        ChargeBar = GameObject.Find("BeamSlider").GetComponent<Slider>();
    }

    void Update()
    {
        if (!charging) return;

        ChargeBar.value = Mathf.Min(ChargeBar.value + Time.deltaTime, 1);

        if (ChargeBar.value >= 1)
            charging = false;
    }
}
