using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance = null;

    [SerializeField] private int GameSceneNumber;
    [SerializeField] private int MenuSceneNumber;
    [SerializeField] public GameObject PausePopup;


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
        SceneManager.LoadScene(GameSceneNumber); // загрузка игровой сцены
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MenuSceneNumber); // загрузка меню сцены
    }

    public void CloseApplication()
    {
        Application.Quit(); // закрытие игры
    }

    public void ShowOrHidePauseMenu()
    {
        PausePopup.SetActive(!PausePopup.activeSelf);
        Cursor.lockState = PausePopup.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}
