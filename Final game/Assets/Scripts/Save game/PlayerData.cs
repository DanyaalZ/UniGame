[System.Serializable]

//serialisable for json
//this is where player data will be stored for saves (high scores)
public class PlayerData
{
  //these are values which will be used for high scores, saved into json, and read for the high scores scene in the main menu
    public int coinAmount;

    //time remaining
    public float time;
    
    //setters
    public void setCoinAmount(int amount)
    {
      coinAmount = amount;
    }

    public void setTimeAmount(float amount)
    {
      time = amount;
    }

    //getters
    public int getCoinAmount()
    {
      return coinAmount;
    }

    public float getTimeAmount()
    {
      return time;
    }
}

