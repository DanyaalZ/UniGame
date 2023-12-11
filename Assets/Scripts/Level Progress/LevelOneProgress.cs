    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;


    public class LevelOneProgress : MonoBehaviour
    {
        public TMP_Text coinTextDisplay;
        public AlertWindow alert;

        private bool completeMessageShown = false;
        private bool reminderMessageShown = false; 

        public coinText coinTextReset; 

        public void Start()
        {
            //ensure player starts on 0 coins (e.g. if they die or come from another level)
            coinTextReset.resetCoins();
        }

        // Update is called once per frame
        public void Update()
        {
            //coins cannot be higher than 10
            if (coinText.coinAmount > 10)
            {
                coinTextReset.resetCoins();
            }

            //if all coins achieved for level one, progress message shown
            if (coinTextDisplay.text == "Coins: 10" && !completeMessageShown)
            {
                alert.showAlert("Level One complete! Enter the portal to continue.");
                completeMessageShown = true;
            }

            //at 3 coins, remind player of objective    
            if (coinTextDisplay.text == "Coins: 3" && !reminderMessageShown)
            {
                alert.showAlert("Good, remember to collect all coins or you won't progress to the next level.");
                reminderMessageShown = true;
            }
        }
    }
