using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class SaveControllerMax
{

    // VARS

    private static SaveData _saveData = new SaveData();


    // METHODS

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
    }
    public static void Load()
    {
        if (File.Exists(SaveFileName()))
        {
            _saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(SaveFileName()));
            PlayerControllerMax.Instance.Load(ref _saveData.PlayerData);
        }
    }
    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath  + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData));
    }

    private static void HandleSaveData()
    {
        _saveData.PlayerData.Position = PlayerControllerMax.Instance.transform.position;
    }
}
