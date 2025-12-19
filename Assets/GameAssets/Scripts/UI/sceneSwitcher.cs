using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public void switchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //load scene condition
    }
    
    public void quitGame()
    {
        Application.Quit(); //quit game condition
    }
}
