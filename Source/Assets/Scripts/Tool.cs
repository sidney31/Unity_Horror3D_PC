using UnityEngine;

[CreateAssetMenu(fileName = "ItemName", menuName = "CreateItem")]
public class Tool : ScriptableObject
{
    public string type;
    public GameObject model;
    public int index;
}
