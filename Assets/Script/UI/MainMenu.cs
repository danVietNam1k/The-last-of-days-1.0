using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu, _CutScene;    
    public void ButtonStart()
    {
        _mainMenu.SetActive(false);
        _CutScene.SetActive(true);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
