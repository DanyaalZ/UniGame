using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/*
 This is to allow enter key to be pressed to activate button, as cursor is locked.
 */
public class AlertButtonPress : MonoBehaviour
{
    public Button button;

    //get function from alert window
    public AlertWindow alert;

    private void Start()
    {
        //listen for enter key press
        EventSystem.current.SetSelectedGameObject(button.gameObject);

        //add event handler for key press
        //close window when button clicked
        if (button != null)
        {
            button.onClick.AddListener(closeWindow);
        }
    }

    //when button clicked set alert window to close
    void closeWindow()
    {
        alert.alertWindow.SetActive(false);
    }

    //handle when enter key pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            button.onClick.Invoke();
        }
    }
}