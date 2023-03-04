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
        if (Vector3.Distance(transform.position, player.position) < 2)
        {
            CanvasManager.instance.SetHintText($"Испульзйте ЛКМ, чтобы подобрать {ToolData.RUName.ToLower()}");
            if (Input.GetMouseButton(0))
            {
                if (ToolsManager.instance.AddToolInInventory(ToolData))
                {
                    CanvasManager.instance.ClearHintText();
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }

    public void OnMouseExit()
    {
        CanvasManager.instance.ClearHintText();
    }
}
