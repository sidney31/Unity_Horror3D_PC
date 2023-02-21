using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController CharController;
    [SerializeField] private GameObject door;
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private Transform GroundChecker;
    [SerializeField] private float CheckerRadius = .4f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool OnGround;
    [SerializeField] private float JumpHeight = 1;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // ��������� ������� �������� �� x z
        CharController.Move(move * speed * Time.deltaTime); // �������� 

        velocity.y += gravity * Time.deltaTime;
        CharController.Move(velocity * Time.deltaTime); // �������� �� y

        OnGround = Physics.CheckSphere(GroundChecker.position, CheckerRadius, GroundLayer); // �������� �� ������� � ������

        if (Input.GetKey(KeyCode.Space) && OnGround) // ������
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        if (Input.GetKey(KeyCode.LeftControl)) // ��������
        {
            Debug.Log("sit");
            transform.localScale = new Vector3(1, 0.5f, 1);
            speed = 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) // ��������� ����� ����������
        {
            if (OnGround) { velocity.y = Mathf.Sqrt(0.5f * -2 * gravity); }
            transform.localScale = new Vector3(1, 1, 1); 
            speed = 5;
        }

        if (velocity.y < 0 && OnGround) // ��������� �������� ���������� �������
        {
            velocity.y = -2;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse 0");
            door.GetComponent<DoorLogic>().MoveDoor();
        }
    }
}
