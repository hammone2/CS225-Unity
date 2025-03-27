using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;
    private bool m_isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_isPaused = !m_isPaused;
            m_pauseMenu.SetActive(m_isPaused);
            Cursor.visible = m_isPaused;
            if (m_isPaused)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void OnLoadButtonPressed()
    {
        SaveManager.Load();
    }
}
