using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private int GameSceneNumber;
    [SerializeField] private int MenuSceneNumber;

    public void ToGame()
    {
        SceneManager.LoadScene(GameSceneNumber); // загрузка игровой сцены
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(MenuSceneNumber); // загрузка меню сцены
    }

    public void CloseApp()
    {
        Application.Quit(); // закрытие игры
    }
}
