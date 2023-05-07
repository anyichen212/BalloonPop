using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tog : MonoBehaviour
{
    public TextMeshProUGUI txt;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Toggle>().isOn)
        txt.text = "ON";
        else
        txt.text = "OFF";
    }
}
