using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] private Tool[] ToolsInInvenotry;
    [SerializeField] private Tool ToolInHands;
    [SerializeField] private int InventorySize;

    public Tool GetToolInHands()
    {
        return ToolInHands;
    }

    public void SetToolInHands(Tool tool)
    {
        ToolInHands = tool;
    }

    public bool AddToolInInvenory(Tool tool)
    {
        if (ToolsInInvenotry.Length > 3)
            return false;

        for (int i = 0; i <= InventorySize; i++)
        {
            if (ToolsInInvenotry[i] == null)
            {
                ToolsInInvenotry[i] = tool;
                return true;
            }
        }

        return false;
    }

    public bool RemoveToolFromInventory(Tool tool)
    {
        for (int i = 0; i <= InventorySize; i++)
        {
            if (ToolsInInvenotry[i] == tool)
            {
                ToolsInInvenotry[i] = null;
                return true;
            }
        }
        return false;
    }
}
