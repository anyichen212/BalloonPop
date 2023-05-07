using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject controller;

    private void Awake() {
        //inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
    }

    public void Show(){
        gameObject.SetActive(true);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }

    public void Enter()
    {
        controller.GetComponent<PersistentData>().SetName(inputField.text);

    }
}
