using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 5;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool OnGround;
    [SerializeField] private float JumpHeight = 1;

    private void FixedUpdate()
    {
        OnGround = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundLayer);

        if (OnGround && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (OnGround && Input.GetKey(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
