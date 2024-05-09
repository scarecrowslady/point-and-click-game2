using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Build.Content;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public bool isGameSaved;

    #region Awake Function
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }
    #endregion

    [System.Serializable]
    class SaveData
    {
        public bool IsGameSaved;
        public Dictionary<int, int> itemsCollectedID = new Dictionary<int, int>();
    }

    public void SaveInfo()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        SaveData data = new SaveData();

        data.IsGameSaved = isGameSaved;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadInfo()
    {       
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            isGameSaved = data.IsGameSaved;
        }
        else
        {
            Debug.Log("there is no save file");
        }
    }
}
