using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class AccelerometerHandler : MonoBehaviour
{
    private Gamepad virtualGamepad;
    public TextMeshProUGUI TextMeshPro;

    Vector3 calibratedZero = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Check if an accelerometer is available and enable it
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            virtualGamepad = InputSystem.AddDevice<Gamepad>();
            Screen.sleepTimeout = SleepTimeout.NeverSleep; // Prevent screen from sleeping
            Calibrate();
        }
        else
        {
            Debug.LogWarning("No accelerometer found!");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SimulateVector2Input(Accelerometer.current.acceleration.ReadValue() - calibratedZero);
    }

    public void Calibrate()
    {
        calibratedZero = Accelerometer.current.acceleration.ReadValue();
        TextMeshPro.gameObject.SetActive(true);
        StartCoroutine(SetTextOff());
    }
    private IEnumerator SetTextOff()
    {
        yield return new WaitForSeconds(1);
        TextMeshPro.gameObject.SetActive(false);
    }


    float deadZone = .10f;
    private void SimulateVector2Input(Vector2 direction)
    {
        var cleanedDirection = new Vector2(Math.Abs(direction.x) < deadZone ? 0 : direction.x, Math.Abs(direction.y) < deadZone ? 0 : direction.y);

        var state = new GamepadState();

        state.leftStick = cleanedDirection * 5;
        InputSystem.QueueDeltaStateEvent(virtualGamepad, state);
    }
}
