using System.Collections;
using UnityEngine;

public class RandomFlashing : MonoBehaviour
{
    [SerializeField] private Vector2 Intensity;
    [SerializeField] private Vector2 Speed;
    [SerializeField] private Light LightSource;

    private void Start()
    {
        LightSource = GetComponent<Light>();
        StartCoroutine(RandomFlashLight());
    }

    private IEnumerator RandomFlashLight()
    {
        while (true)
        {
            LightSource.intensity = Random.Range(Intensity.x, Intensity.y);
            yield return new WaitForSeconds(Random.Range(Speed.x, Speed.y)  * Time.deltaTime);
        }
    }
}