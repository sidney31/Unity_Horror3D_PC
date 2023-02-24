using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(Player.position);
        Quaternion temp = transform.rotation;
        temp.x = 0;
        temp.z = 0;
        transform.rotation = temp;
    }


}
