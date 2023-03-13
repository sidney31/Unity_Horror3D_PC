using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private PlayerController _PlayerController;
    [SerializeField] private float WalkSpeed = 3;
    [SerializeField] private float SitSpeed = 2;
    [SerializeField] private float JumpHeight = 1;
    [SerializeField] private float JumpRate = 0.5f;
    [SerializeField] private float NextJumpTime;
    [SerializeField] private float SitRate = 0.5f;
    [SerializeField] private float NextSitTime;
    [SerializeField] private float MaxFlashlightIntensity = 1.5f;
    [SerializeField] private bool Sit;
    [SerializeField] private Tool ToolInHands;
    [SerializeField] private float DefaultHeight = 1.7f;

    private void Start()
    {
        NextJumpTime = 0;
        NextSitTime = 0;
        WalkSpeed = PlayerController.WalkSpeed;
        SitSpeed = PlayerController.SitSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        _PlayerController.velocity = Vector3.zero;
    }

    private void Update()
    {
        CheckKeysPress();
    }

    private void CheckKeysPress()
    {
        ToolInHands = ToolsManager.instance.GetToolInHands();

        if (ToolInHands?.type != Tool.ToolType.flashlight)
        {
            Camera.main.GetComponentInChildren<Light>().intensity = 0;
        }

        if (Input.GetKey(KeyCode.Space) && _PlayerController.OnGround && Time.time >= NextJumpTime) // ������
        {
            _PlayerController.velocity.y = Mathf.Sqrt(JumpHeight * -2 * _PlayerController.gravity);
            NextJumpTime = Time.time + JumpRate;
        }

        if (Input.GetKey(KeyCode.LeftControl) && Time.time >= NextSitTime && !Sit &&_PlayerController.OnGround) // ��������
        {
            GetComponent<CharacterController>().height = 1;
            _PlayerController.CurrentSpeed = SitSpeed;
            NextSitTime = Time.time + SitRate;
            Sit = true; 
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && Sit) // ��������� ����� ����������
        {
            _PlayerController.velocity.y = Mathf.Sqrt(-.7f * _PlayerController.gravity * 1); // e = sqrt(mgh) 
            GetComponent<CharacterController>().height = DefaultHeight;
            _PlayerController.CurrentSpeed = WalkSpeed;
            Sit = false;
        }

        if (_PlayerController.velocity.y < 0 && _PlayerController.OnGround) // ��������� �������� ���������� �������
        {
            _PlayerController.velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.F) && ToolInHands?.type == Tool.ToolType.flashlight) // ������ ���������
        {
            Camera.main.GetComponentInChildren<Flashlight>().NextFlashState();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // �������� ����
        {
            ButtonManager.instance.ShowOrHidePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q) && ToolInHands?.index > 0) // ������������ ���������
        {
            ToolsManager.instance.SetToolInHands(ToolsManager.instance.GetToolsInInvenory()[ToolInHands.index - 1]);
        }
        
        if (Input.GetKeyDown(KeyCode.E) && ToolInHands?.index < ToolsManager.instance.GetToolsInInvenory().Length - 1)
        {
            ToolsManager.instance.SetToolInHands(ToolsManager.instance.GetToolsInInvenory()[ToolInHands.index + 1]);
        }
    }

}
