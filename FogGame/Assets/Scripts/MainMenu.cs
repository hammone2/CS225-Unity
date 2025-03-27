using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void OnNewGameButtonPressed()
    {
        SaveManager.NewSave();
    }
    public void OnLoadGameButtonPressed()
    {
        SaveManager.Load();
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit(); //this wont work when running in the editor, just stop the game normally
    }
}
