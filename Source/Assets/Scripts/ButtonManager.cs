using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance = null;

    [SerializeField] public int GameSceneNumber;
    [SerializeField] public int MenuSceneNumber;

    [SerializeField] public GameObject PauseMenu;
    [SerializeField] public GameObject SettingsMenu;
    [SerializeField] public GameObject MainMenu;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
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

    public void ShowOrHidePauseMenu() // ��������/�������� ����
    {
        if (SettingsMenu.activeSelf)
            return;

        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Cursor.lockState = PauseMenu.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    public void ShowOrHideSettingsMenu() // ��������/�������� ��������
    {
        SettingsMenu.SetActive(!SettingsMenu.activeSelf);

        if (PauseMenu)
            PauseMenu.SetActive(!SettingsMenu.activeSelf);
        if (MainMenu)
            MainMenu.SetActive(!SettingsMenu.activeSelf);
    }

}
