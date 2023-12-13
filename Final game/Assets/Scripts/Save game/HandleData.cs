using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

//this allows us to save, read, overwrite user game data
//we are using json
public class HandleData : MonoBehaviour
{
 public void saveData(PlayerData data)
 {
    string path = Application.persistentDataPath + "/playerData.json";

    // Check if a file for the current name already exists
    if (File.Exists(path))
    {
        string jsonData = File.ReadAllText(path);
        PlayerData existingData = JsonConvert.DeserializeObject<PlayerData>(jsonData);

        if (existingData != null && existingData.name == data.name)
        {
            // Overwrite the existing data
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
            return;
        }
    }

    // Create new data if no existing data is found
    string newJson = JsonConvert.SerializeObject(data);
    File.WriteAllText(path, newJson);
   }
}
