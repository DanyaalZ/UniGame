using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveText : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Remove");
        text.enabled = false;
    }
}
