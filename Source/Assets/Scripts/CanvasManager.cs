using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] private TMP_Text hint;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
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
