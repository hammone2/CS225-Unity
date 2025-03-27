using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string levelToSwitch;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Loaded new scene: " + levelToSwitch);
            SceneManager.LoadScene(levelToSwitch);
            SaveManager.Save();
        }
    }
}
