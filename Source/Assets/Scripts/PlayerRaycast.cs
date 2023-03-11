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

        if (Physics.Raycast(ray, out hit, MaxRayDist))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.white);

            if (hit.collider.tag == "Door")
            {
                CanvasManager.instance.SetHintText("Нажмите ЛКМ, чтобы открыть дверь.");
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (Input.GetMouseButton(0))
                    hit.collider.GetComponent<DoorLogic>().DoorInteractive();
            }
            else if (hit.collider.tag == "Tool")
            {
                CanvasManager.instance.SetHintText($"Нажмите ЛКМ, чтобы взять {hit.collider.GetComponent<ToolAvailableForTaking>().ToolData.RUName}.");
                Debug.DrawLine(ray.origin, hit.point, Color.blue);
                if (Input.GetMouseButton(0))
                    hit.collider.GetComponent<ToolAvailableForTaking>().TakeToolInHands();
            }
            else
            {
                CanvasManager.instance.ClearHintText();
            }
        }
        else
        {
            CanvasManager.instance.ClearHintText();
        }
    }
}
