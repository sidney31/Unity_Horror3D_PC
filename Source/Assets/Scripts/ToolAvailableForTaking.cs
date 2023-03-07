using UnityEngine;

public class ToolAvailableForTaking : MonoBehaviour
{
    [SerializeField] public Tool ToolData;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void OnMouseOver()
    {
        Debug.Log("overlap");
        if (Vector3.Distance(transform.position, player.position) < 100)
        {
            CanvasManager.instance.SetHintText($"Нажмите ЛКМ, чтобы подобрать {ToolData.RUName.ToLower()}");
            if (Input.GetMouseButton(0))
            {
                if (ToolsManager.instance.AddToolInInventory(ToolData))
                {
                    CanvasManager.instance.ClearHintText();
                    Destroy(transform.parent.gameObject);
                }
            }
        }
        else
        {
            CanvasManager.instance.ClearHintText();
        }
    }

    public void OnMouseExit()
    {
        CanvasManager.instance.ClearHintText();
    }
}
