using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance = null;
    [SerializeField] private Tool[] ToolsInInventory = new Tool[3];
    [SerializeField] private Tool ToolInHands;
    [SerializeField] public GameObject Hands;

    [SerializeField] public Tool FlashLight;
    [SerializeField] public Tool Key;

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

        SpawnNewToolInCords(FlashLight, Vector3.zero, Quaternion.identity);
        SpawnNewToolInCords(Key, new Vector3(1, -.2f, 3), Quaternion.identity);
     
    }

    public Tool GetToolInHands()
    {
        if (ToolInHands)
            return ToolInHands;
        
        return null;
    }

    public void SetToolInHands(Tool tool)
    {
        if (tool == null)
            return;

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
        for (int i = 0; i < GetToolsInInvenory().GetLength(0); i++)
        {
            if (GetToolsInInvenory()[i] == null)
            {
                if (!GetToolInHands())
                {
                    SetToolInHands(tool);
                }
                ToolsInInventory[i] = tool;
                UpdateToolsIndex();
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
            if (tool)
            {
                tool.index = index;
                index++;
            }
        }
    }

    public Tool[] GetToolsInInvenory()
    {
        return ToolsInInventory;
    }

    public void SpawnNewToolInCords(Tool tool, Vector3 cord, Quaternion quaternion)
    {
        GameObject NewToolInGround = Instantiate(tool.model, cord, quaternion);
        NewToolInGround.transform.GetChild(0).gameObject.AddComponent<ToolAvailableForTaking>();
        NewToolInGround.GetComponentInChildren<ToolAvailableForTaking>().ToolData = tool;
    }
}
