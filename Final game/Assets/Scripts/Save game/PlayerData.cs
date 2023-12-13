[System.Serializable]

//serializable for json
//this is where player data will be stored for saves
public class PlayerData
{
    public int coinAmount;
    public float time;
    public string name;
}


//to use for saving
//public void SaveGame()
  //  {
    //    PlayerData data = new PlayerData
      //  {
        //    coinAmount = this.coinAmount,
          //  time = this.time,
            //name = this.playerName
        //};

        //saveManager.SaveData(data);
    //}