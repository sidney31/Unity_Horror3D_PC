using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject spotlight;
    [SerializeField] private float WalkSpeed = 3;
    [SerializeField] private float SitSpeed = 2;
    [SerializeField] private float JumpHeight = 1;
    [SerializeField] private float JumpRate = 0.5f;
    [SerializeField] private float NextJumpTime;

    [SerializeField] private GameObject PopupMenu;
    [SerializeField] private LayerMask DoorLayer;

    private void Start()
    {
        NextJumpTime = 0;
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

        if (Input.GetKey(KeyCode.LeftControl)) // присесть
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            playerController.CurrentSpeed = SitSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) // обнуление после приседания
        {
            if (playerController.OnGround) { playerController.velocity.y = Mathf.Sqrt(0.5f * -2.5f * playerController.gravity); }
            transform.localScale = new Vector3(1, 1, 1);
            playerController.CurrentSpeed = WalkSpeed;
        }

        if (playerController.velocity.y < 0 && playerController.OnGround) // обнуление скорости свободного падения
        {
            playerController.velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.F)) // де/активация фонарика
        {
            spotlight.SetActive(!spotlight.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // открытие меню
        {
            PopupMenu.SetActive(!PopupMenu.activeSelf);
            Cursor.lockState = PopupMenu.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
        }

        if (Input.inputString != null) // режимы фонарика
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number >= 1 && number <= 3)
            {
                spotlight.GetComponent<Light>().intensity = number;
            }
        }

        /*
            float mouseWheel = Input.GetAxis("Mouse ScrollWheel"); // радиус света
            mouseWheel = Mathf.Clamp(mouseWheel, -1, 1);
            spotlight.GetComponent<Light>().range -= mouseWheel * 3;
        */
    }

}
