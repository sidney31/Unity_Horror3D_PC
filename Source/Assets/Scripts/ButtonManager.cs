using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private int GameSceneNumber;
    [SerializeField] private int MenuSceneNumber;

    public void ToGame()
    {
        SceneManager.LoadScene(GameSceneNumber);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(MenuSceneNumber);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
