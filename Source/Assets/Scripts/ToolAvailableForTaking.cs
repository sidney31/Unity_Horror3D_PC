using UnityEngine;

public class ToolAvailableForTaking : MonoBehaviour
{
    [SerializeField] public Tool ToolData;

    public void TakeToolInHands()
    {
        if (ToolsManager.instance.AddToolInInventory(ToolData))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
