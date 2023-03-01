using System.Linq;
using UnityEngine;
using UnityEngine.XR;

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

    private void Update()
    {
        SwitchToolInHands();
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

    private void SwitchToolInHands()
    {
        if (Input.GetKeyDown(KeyCode.Q) && GetToolInHands().index > 0)
        {
            SetToolInHands(ToolsInInventory[GetToolInHands().index-1]);
        }

        if (Input.GetKeyDown(KeyCode.E) && GetToolInHands().index < ToolsInInventory.Length-1)
        {
            SetToolInHands(ToolsInInventory[GetToolInHands().index+1]);
        }
    }

    public bool AddToolInInventory(Tool tool)
    {
        if (ToolsInInventory.Length < InventorySize) 
        {
            ToolsInInventory.Append(tool);
            UpdateToolsIndex();
            return true;
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
}
