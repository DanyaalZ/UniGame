using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GravityText : MonoBehaviour
{
    public TMP_Text gravityText;

    // Start is called before the first frame update
    void Start()
    {
        updateText(true);
    }

    public void updateText(bool isGravity)
    {
        gravityText.text = isGravity ? "Gravity: On" : "Gravity: Off";
    }
}
