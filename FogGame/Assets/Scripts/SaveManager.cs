using UnityEngine;

public static class SaveManager
{
    public static SaveFile save;

    /// <summary>
    /// Saves the game.
    /// </summary>
    public static void Save()
    {
        save++;
    }
}
