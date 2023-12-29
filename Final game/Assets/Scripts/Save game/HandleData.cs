using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//newtonsoft package has been installed separately
using Newtonsoft.Json;

//this allows us to save, read, overwrite user game data
//we are using json
public class HandleData : MonoBehaviour
{

 //path where data is stored as json
 private string path = Application.dataPath + "/Scripts/Save game/highscoreData.json";
 public void saveData(PlayerData data)
 {
    //check if it already exists to we can write to it
    if (File.Exists(path))
    {
        string jsonData = File.ReadAllText(path);
        //get existing data in json as a normal object (deserialised)
        PlayerData existingData = JsonConvert.DeserializeObject<PlayerData>(jsonData);

        //if highscore met and there is existing data, save
        //must have the highest amount of coins and highest time left to be considered highscore
        if ((existingData != null) && (existingData.getCoinAmount() < data.getCoinAmount()) && (existingData.getTimeAmount() < data.getTimeAmount()))
        {
            //overwrite existing data, changing values
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
            return;
        }
    }

    //otherwise create new json file to read from in future (in case it's been deleted for whatever reason)
    string newJson = JsonConvert.SerializeObject(data);
    File.WriteAllText(path, newJson);
   }

   //load json and deserialise data to return as string
   public string loadData()
   {
       string jsonData = File.ReadAllText(path);
       PlayerData existingData = JsonConvert.DeserializeObject<PlayerData>(jsonData);
       return jsonData;
   }
}
