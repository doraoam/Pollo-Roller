using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.gs");
        GameData data = new GameData();
        data.score = Score.totalScore;
        data.level = Application.loadedLevelName;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.gs"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.gs", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            Score.totalScore = data.score;
            Application.LoadLevel(data.level);
        }
    }
}
