using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadData : MonoBehaviour
{
    public TMP_Text highScoresText;

    //to get load data function
    public HandleData handleData;
    void Start()
    {
        string highScoresString = handleData.loadData();
        //set text as loaded data
        highScoresText.text = $"High Scores: \n {highScoresString}";
    }
}
