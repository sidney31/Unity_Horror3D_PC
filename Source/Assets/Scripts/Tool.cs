using UnityEngine;

[CreateAssetMenu(fileName = "ItemName", menuName = "CreateItem")]
public class Tool : ScriptableObject
{
    public string RUName;
    public ToolType type;
    public enum ToolType {flashlight, key};
    public GameObject model;
    public int index;
}
