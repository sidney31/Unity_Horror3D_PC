using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController CharController;
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private Transform GroundChecker;
    [SerializeField] private float CheckerRadius = .4f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool OnGround;
    [SerializeField] private float JumpHeight = 1;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        CharController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        CharController.Move(velocity * Time.deltaTime);

        OnGround = Physics.CheckSphere(GroundChecker.position, CheckerRadius, GroundLayer);

        if (Input.GetKey(KeyCode.Space) && OnGround)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        if (velocity.y < 0 && OnGround)
        {
            velocity.y = -2;
        }
    }
}
