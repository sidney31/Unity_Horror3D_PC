using UnityEngine;
using TMPro;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] private TMP_Text hint;
    [SerializeField] private bool HintIsActive;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        hint.color = new Color(255, 255, 255, 0);
    }

    public void SetHintText(string text)
    {
        if (text == hint.text || HintIsActive)
            return;

        HintIsActive = true;
        hint.text = text;
        StartCoroutine(ShowHint()); 
    }

    public void ClearHintText()
    {
        if (HintIsActive || hint.text == string.Empty)
            return;

        HintIsActive = true;
        StartCoroutine(HideHint());
    }

    private IEnumerator ShowHint()
    {
        for (float i = .0f; i <= 1.1f; i += .05f)
        {
            hint.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(Time.deltaTime * 2);
        }
        HintIsActive = false;
    }


    private IEnumerator HideHint()
    {
        for (float i = 1; i >= -0.1f; i -= .05f)
        {
            hint.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(Time.deltaTime * 2);
        }
        HintIsActive = false;
        hint.text = string.Empty;
    }
}
