using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHover : MonoBehaviour
{
    //import textmeshpro to allow text change
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        //get text from object
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        //start with colour as black
        textMeshProUGUI.color = Color.black;
    }

    private void OnMouseEnter()
    {
        //change text colour to yellow when the mouse hovers on txt
        textMeshProUGUI.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        //change text color back to black when the mouse is no longer on the text
        textMeshProUGUI.color = Color.black;
    }
}
