using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance = null;

    [SerializeField] public int GameSceneNumber;
    [SerializeField] public int MenuSceneNumber;
    [SerializeField] public int SettingsSceneNumber;

    [SerializeField] public GameObject PauseMenu;

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
        PauseMenu = GameObject.FindWithTag("PauseMenu");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MenuSceneNumber); // �������� ���� �����
    }

    public void LoadSettingsScene()
    {
        PlayerPrefs.SetInt("LastSceneNumber", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().name + "  " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SettingsSceneNumber); // �������� ���� �����
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastSceneNumber"));
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
