using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnNewGameButtonPressed()
    {
        //put new save code here
        SceneManager.LoadScene("Level1");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit(); //this wont work when running in the editor, just stop the game normally
    }
}
