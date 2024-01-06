using UnityEngine;
using Newtonsoft.Json;

/* Handle saved data - this has been changed from using an external json file to use playerprefs for webgl*/
public class HandleData : MonoBehaviour
{
    private string dataKey = "PlayerData";

    //save data - works for level 1 and 2 - if the player dies and goes back to menu or if they pass level 2 (cutscene between 2 and 3)
    public void saveData(PlayerData data)
    {
        //check if player data already exists
        if (PlayerPrefs.HasKey(dataKey))
        {
            //get existing data - if it doesn't exist will be null
            string existingJsonData = PlayerPrefs.GetString(dataKey);
            //convert to player data object (we have created this in another script)
            PlayerData existingData = JsonConvert.DeserializeObject<PlayerData>(existingJsonData);

            //check if new data meets high score conditions given that there is existing data already
            //conditions: coin amount higher or the same, time lower
            if (existingData != null && existingData.getCoinAmount() >= data.getCoinAmount() && existingData.getTimeAmount() >= data.getTimeAmount())
            {
                //create new json text to set new high score 
                string newJson = JsonConvert.SerializeObject(data);
                PlayerPrefs.SetString(dataKey, newJson);
                PlayerPrefs.Save();
            }
        }
        else
        {
            //if no data exists, save new data - we dont need to check conditions as there is nothing there already
            string newJson = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(dataKey, newJson);
            PlayerPrefs.Save();
        }
    }

    //load data, used in view high scores scene for main menu
    public string loadData()
    {
        //if there is existing data return it to display
        if (PlayerPrefs.HasKey(dataKey))
        {
            return PlayerPrefs.GetString(dataKey);
        }

        else
        {
            return null;
        }
    }
}
