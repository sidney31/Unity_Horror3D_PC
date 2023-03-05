using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private float MaxFlashlightIntensity = 1.5f;

    public void NextFlashState()
    {
        Light flashlight = Camera.main.GetComponentInChildren<Light>();

        if (flashlight.intensity >= MaxFlashlightIntensity)
        {
            flashlight.intensity = 0;
        }
        else
        {
            flashlight.intensity += MaxFlashlightIntensity / 3;
        }
    }
}
