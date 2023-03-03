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
            CanvasManager.Instance.SetHintText($"Испульзйте ЛКМ, чтобы подобрать {ToolData.type}");
            if (Input.GetMouseButton(0))
            {
                if (ToolsManager.Instance.AddToolInInventory(ToolData))
                {
                    CanvasManager.Instance.ClearHintText();
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }

    public void OnMouseExit()
    {
        CanvasManager.Instance.ClearHintText();
    }
}
