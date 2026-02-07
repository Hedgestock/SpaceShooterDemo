using UnityEngine;

using UnityEngine;

public class AspectRatioEnforcer : MonoBehaviour
{
    void Start()
    {
        // Set a fixed resolution of 1920x1080 in windowed mode
        Debug.Log("Current resolution: " + Screen.width + "x" + Screen.height);
        //Screen.SetResolution(1080/4, 1920/4, false);
    }
}