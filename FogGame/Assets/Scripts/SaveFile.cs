using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveFile
{
    public string fileName;
    public int sceneIndex;

    /// <summary>
    /// Gets the file path.
    /// </summary>
    private string FilePath { get => $"{Application.persistentDataPath}/{fileName}.dat"; }
    /// <summary>
    /// Increments the save's scene index by one.
    /// </summary>
    /// <param name="save">The save to increment.</param>
    /// <returns>The incremented save.</returns>
    public static SaveFile operator ++ (SaveFile save)
    {
        save.sceneIndex++;

        BinaryFormatter bf = new();
        FileStream file;

        if (File.Exists(save.FilePath))
        {
            file = File.OpenWrite(save.FilePath);
        }
        else
            throw new Exception("File not found.");

        bf.Serialize(file, save);

        file.Close();

        return save;
    }
    /// <summary>
    /// The save file constructor.
    /// </summary>
    /// <param name="sceneIndex">The index of the first level.</param>
    public SaveFile(string fileName, int sceneIndex = 0)
    {
        this.fileName = fileName;

        BinaryFormatter bf = new();
        FileStream file;

        //Load existing save
        if (File.Exists(FilePath))
        {
            if (sceneIndex != 0)
            {
                File.Delete(FilePath);
                Debug.Log("Save file deleted");
                this.sceneIndex = sceneIndex;
                file = File.Create(FilePath);
                bf.Serialize(file, this);
            }
            else
            {
                file = File.OpenRead(FilePath);
                SaveFile loadedSave = bf.Deserialize(file) as SaveFile;
                this.sceneIndex = loadedSave.sceneIndex;
            }
        }
        else
        {
            this.sceneIndex = sceneIndex;
            file = File.Create(FilePath);
            bf.Serialize(file, this);
        }
        file.Close();
    }
}
