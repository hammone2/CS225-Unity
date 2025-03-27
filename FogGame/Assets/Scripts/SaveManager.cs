using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    private const string SAVE_NAME = "Save";
    public static SaveFile saveFile;

    /// <summary>
    /// Saves the game.
    /// </summary>
    public static void Save()
    {
        try
        {
            saveFile++;
        }
        catch
        {
            saveFile = new(SAVE_NAME, SceneManager.GetActiveScene().buildIndex + 1);
        }
        Debug.Log($"Saved at {Application.persistentDataPath}");
    }

    internal static void Load()
    {
        if (saveFile == null)
        {
            saveFile = new(SAVE_NAME);
        }
        try
        {
            SceneManager.LoadScene(saveFile.sceneIndex);
        }
        catch
        {
            SceneManager.LoadScene(0);
        }
    }

    internal static void NewSave()
    {
        saveFile = new(SAVE_NAME, 1);
        SceneManager.LoadScene(saveFile.sceneIndex);
    }
}
