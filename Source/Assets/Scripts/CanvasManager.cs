using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private TMP_Text hint;

    private void Start()
    {
        Instance = this;
    }

    public void SetHintText(string text, float time = 0)
    {
        if (time == 0)
        {
            hint.text = text;
        }
    }

    public void ClearHintText()
    {
        hint.text = string.Empty;
    }
}
