using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private float MaxRayDist;

    private void Start()
    {
        MainCamera = Camera.main;    
    }

    private void Update()
    {

        if (ButtonManager.instance.PauseMenu.activeSelf ||
            ButtonManager.instance.SettingsMenu.activeSelf)
            return;

        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, MaxRayDist))
        {
            if (hit.collider.tag == "Door")
            {
                CanvasManager.instance.SetHintText("Нажмите ЛКМ, чтобы открыть дверь.");

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponentInParent<DoorLogic>().DoorInteractive();
                }
                return;
            }

            if (hit.collider.tag == "Tool")
            {
                CanvasManager.instance.SetHintText($"Нажмите ЛКМ, чтобы взять {hit.collider.GetComponent<ToolAvailableForTaking>().ToolData.RUName}.");

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<ToolAvailableForTaking>().TakeToolInHands();
                }
                return;
            }

            CanvasManager.instance.ClearHintText();
        }
        else
        {
            CanvasManager.instance.ClearHintText();
        }
    }
}
  