using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

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
    [SerializeField] private LayerMask DoorLayer;
    [SerializeField] private Tool ToolInHands;

    private void Start()
    {
        NextJumpTime = 0;
        NextSitTime = 0;
        WalkSpeed = PlayerController.WalkSpeed;
        SitSpeed = PlayerController.SitSpeed;
        Cursor.lockState = CursorLockMode.Locked;
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

        if (Input.GetKey(KeyCode.Space) && _PlayerController.OnGround && Time.time >= NextJumpTime) // прыжок
        {
            _PlayerController.velocity.y = Mathf.Sqrt(JumpHeight * -2 * _PlayerController.gravity);
            NextJumpTime = Time.time + JumpRate;
        }

        if (Input.GetKey(KeyCode.LeftControl) && Time.time >= NextSitTime && !Sit &&_PlayerController.OnGround) // присесть
        {
            GetComponent<CharacterController>().height = 1;
            _PlayerController.CurrentSpeed = SitSpeed;
            NextSitTime = Time.time + SitRate;
            Sit = true; 
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && Sit) // обнуление после приседания
        {
            _PlayerController.velocity.y = Mathf.Sqrt(-1 * _PlayerController.gravity * 1); // e = mgh 
            GetComponent<CharacterController>().height = 2;
            _PlayerController.CurrentSpeed = WalkSpeed;
            Sit = false;
        }

        if (_PlayerController.velocity.y < 0 && _PlayerController.OnGround) // обнуление скорости свободного падения
        {
            _PlayerController.velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.F) && ToolInHands?.type == Tool.ToolType.flashlight) // режимы фонариков
        {
            Camera.main.GetComponentInChildren<Flashlight>().NextFlashState();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // открытие меню
        {
            ButtonManager.instance.ShowOrHidePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q) && ToolInHands?.index > 0) // переключение предметов
        {
            ToolsManager.instance.SetToolInHands(ToolsManager.instance.GetToolsInInvenory()[ToolInHands.index - 1]);
        }
        
        if (Input.GetKeyDown(KeyCode.E) && ToolInHands?.index < ToolsManager.instance.GetToolsInInvenory().Length - 1)
        {
            ToolsManager.instance.SetToolInHands(ToolsManager.instance.GetToolsInInvenory()[ToolInHands.index + 1]);
        }
    }

}
