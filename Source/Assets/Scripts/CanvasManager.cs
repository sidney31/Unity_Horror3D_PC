using UnityEngine;
using TMPro;
using System.Collections;

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

    public void SetHintText(string text)
    {
        if (text == hint.text)
        {
            return;
        }
        StartCoroutine(ShowHint()); 
        hint.text = text;
    }

    public void ClearHintText()
    {
        StartCoroutine(HideHint());
        hint.text = string.Empty;
    }

    private IEnumerator ShowHint()
    {
        for (float i = 0; i <= 1; i++)
        {
            Color TempColor = hint.color;
            TempColor.a = i;
            hint.color = TempColor;
            yield return new WaitForSeconds(Time.deltaTime*10);
        }
    }

    private IEnumerator HideHint()
    {
        for (float i = 1; i >= 0; i--)
        {
            Color TempColor = hint.color;
            TempColor.a = i;
            hint.color = TempColor;
            yield return new WaitForSeconds(Time.deltaTime*10);
        }
    }
}
