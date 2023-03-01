using Unity.VisualScripting;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float WalkSpeed = 3;
    [SerializeField] private float SitSpeed = 2;
    [SerializeField] private float JumpHeight = 1;
    [SerializeField] private float JumpRate = 0.5f;
    [SerializeField] private float NextJumpTime;
    [SerializeField] private float SitRate = 0.5f;
    [SerializeField] private float NextSitTime;
    [SerializeField] private bool Sit;

    [SerializeField] private LayerMask DoorLayer;

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
        if (Input.GetKey(KeyCode.Space) && playerController.OnGround && Time.time >= NextJumpTime) // прыжок
        {
            playerController.velocity.y = Mathf.Sqrt(JumpHeight * -2 * playerController.gravity);
            NextJumpTime = Time.time + JumpRate;
        }

        if (Input.GetKey(KeyCode.LeftControl) && Time.time >= NextSitTime && !Sit) // присесть
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            playerController.CurrentSpeed = SitSpeed;
            NextSitTime = Time.time + SitRate;
            Sit = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && Sit) // обнуление после приседания
        {
            if (playerController.OnGround)
            {
                playerController.velocity.y = Mathf.Sqrt(0.35f * -2.5f * playerController.gravity);
            }
            transform.localScale = new Vector3(1, 1, 1);
            playerController.CurrentSpeed = WalkSpeed;
            Sit = false;
        }

        if (playerController.velocity.y < 0 && playerController.OnGround) // обнуление скорости свободного падения
        {
            playerController.velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.F) && ToolsManager.Instance.GetToolInHands().type == "Flashlight") // де/активация фонарика
        {
            Light flashlight = ToolsManager.Instance.Hands.GetComponentInChildren<Light>();
            flashlight.enabled = (!flashlight.enabled);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // открытие меню
        {
            ButtonManager.Instance.ShowOrHidePauseMenu();
        }

        if (Input.inputString != null) // режимы фонарика
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            Light flashlight = ToolsManager.Instance.Hands.GetComponentInChildren<Light>();
            if (isNumber && number >= 1 && number <= 3)
            {
                flashlight.intensity = number;
            }
        }
    }

}
