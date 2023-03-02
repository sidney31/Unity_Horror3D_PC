using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance = null;
    [SerializeField] private Tool[] ToolsInInventory;
    [SerializeField] private Tool ToolInHands;
    [SerializeField] private int InventorySize;
    [SerializeField] public GameObject Hands;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateToolsIndex();
        SetToolInHands(ToolsInInventory[0]);    
    }

    public Tool GetToolInHands()
    {
        return ToolInHands;
    }

    public void SetToolInHands(Tool tool)
    {
        if (Hands.transform.childCount != 0)
        {
            foreach(Transform child in Hands.transform)
            {
                Destroy(child.gameObject);
            }
        }

        ToolInHands = tool;
        GameObject NewTool = Instantiate(tool.model, Hands.transform.position, Quaternion.identity);
        NewTool.transform.parent = Hands.transform;
        NewTool.transform.rotation = Hands.transform.rotation;
        ToolInHands.index = tool.index;
    }


    public bool AddToolInInventory(Tool tool)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (GetToolsInInvenory()[i] == null)
            {
                ToolsInInventory[i] = tool;
                return true;
            }
        }

        return false;
    }

    private void UpdateToolsIndex()
    {
        int index = 0;
        foreach (Tool tool in ToolsInInventory)
        {
            tool.index = index;
            index++;
        }
    }

    public Tool[] GetToolsInInvenory()
    {
        return ToolsInInventory;
    }
}
