using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SprintText : MonoBehaviour
{
    public TMP_Text sprintText;

    // Start is called before the first frame update
    void Start()
    {
        updateText(false);
    }

    public void updateText(bool isSprinting)
    {
        sprintText.text = isSprinting ? "Sprint: On" : "Sprint: Off";
    }
}
