using UnityEngine;

public class RandomFlashing : MonoBehaviour
{

    private void Update()
    {
        int rand = Random.Range(0, 100);

        if (rand == 0)
        {
            GetComponent<Light>().intensity = Random.Range(1, 4);
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }
}
