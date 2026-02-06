using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{

    bool charging = false;
    private Slider ChargeBar;

    public void ChargeFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            charging = true;
        }
        if (context.canceled)
        {
            charging = false;
            if (ChargeBar.value > .93f)
            {
                gameObject.SendMessage("FireCharged");
                ChargeBar.value = 0;
            }
            else
                gameObject.SendMessage("OnFire");
            ChargeBar.value = 0;
        }
    }

    void Awake()
    {
        ChargeBar = GameObject.Find("BeamSlider").GetComponent<Slider>();
    }

    void Update()
    {
        if (!charging) return;

        ChargeBar.value = Mathf.Min(ChargeBar.value + Time.deltaTime, 1);
    }
}
