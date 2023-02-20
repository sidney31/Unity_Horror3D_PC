using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 MovementAsix;
    [SerializeField] private float speed = 3;

    private void FixedUpdate()
    {
        Camera.main.transform.position = transform.position;
        MovementAsix.x = Input.GetAxis("Vertical");
        MovementAsix.y = Input.GetAxis("Horizontal");
        transform.position += new Vector3(MovementAsix.y, 0, MovementAsix.x) * Time.deltaTime * speed;
    }
}
