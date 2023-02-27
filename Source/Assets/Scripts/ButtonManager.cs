using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance = null;

    [SerializeField] private int GameSceneNumber;
    [SerializeField] private int MenuSceneNumber;
    [SerializeField] public GameObject PauseMenu;
    //[SerializeField] public GameObject MainButtons;
    //[SerializeField] public GameObject SettingsMenu;

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
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameSceneNumber); // �������� ������� �����
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MenuSceneNumber); // �������� ���� �����
    }

    public void CloseApplication()
    {
        Application.Quit(); // �������� ����
    }

    public void ShowOrHidePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Cursor.lockState = PauseMenu.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    //public void ShowOrHideSettingsMenu()
    //{
    //    MainButtons.SetActive(!MainButtons.activeSelf);
    //    SettingsMenu.SetActive(!SettingsMenu.activeSelf);
    //}
}
