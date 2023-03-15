using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController CharController;
    [SerializeField] internal float CurrentSpeed;
    [SerializeField] internal const float WalkSpeed = 3;
    [SerializeField] internal const float SitSpeed = 2;
    [SerializeField] internal Vector3 velocity;
    [SerializeField] internal float gravity = -6.8f;

    [SerializeField] private Transform GroundChecker;
    [SerializeField] private float CheckerRadius = .4f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] internal bool OnGround;

    private void Start()
    {
        CurrentSpeed = WalkSpeed;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (ButtonManager.instance.PauseMenu.activeSelf ||
            ButtonManager.instance.SettingsMenu.activeSelf)
            return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // ��������� ������� �������� �� x z
        CharController.Move(move * CurrentSpeed * Time.deltaTime); // �������� 

        velocity.y += gravity * Time.deltaTime;
        CharController.Move(velocity * Time.deltaTime); // �������� �� y

        OnGround = Physics.CheckSphere(GroundChecker.position, CheckerRadius, GroundLayer); // �������� �� ������� � ������
    }
}
