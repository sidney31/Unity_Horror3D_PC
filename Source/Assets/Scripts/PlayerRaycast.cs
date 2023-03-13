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
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, MaxRayDist))
            {
                if (hit.collider.tag == "Door")
                {
                    CanvasManager.instance.SetHintText("Нажмите ЛКМ, чтобы открыть дверь.");
                    hit.collider.GetComponentInParent<DoorLogic>().DoorInteractive();
                }

                if (hit.collider.tag == "Tool")
                {
                    CanvasManager.instance.SetHintText($"Нажмите ЛКМ, чтобы взять {hit.collider.GetComponent<ToolAvailableForTaking>().ToolData.RUName}.");
                    hit.collider.GetComponent<ToolAvailableForTaking>().TakeToolInHands();
                }
            }
        }
        CanvasManager.instance.ClearHintText();
    }
}
