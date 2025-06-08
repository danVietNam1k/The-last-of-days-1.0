using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] GameObject _buttonPause, 
        _buttonContinue, _buttonMainMenu, _buttonExit
        ;
    public void ButtonMenu()
    {
        _buttonPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ButtonContinue()
    {
        _buttonPause.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }
    public void ButtonMainMenu() 
    {
        SceneManager.LoadScene(CONSTANT.MainMenu);
            }
    public void ButtonExit() {
        Application.Quit();
    }
    public void ButtonPlayAgain()
    {
        SceneManager.LoadScene(CONSTANT.MainMenu);
    }
}
