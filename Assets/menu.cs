using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class menu : MonoBehaviour
{
    public Toggle t;
    public GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4){
            g.SetActive(false);
        }

        if(!t.isOn){
            g.SetActive(false);
        }
    }

    public void StartGame(){
        if(!t.isOn)
        Destroy(g);

        SceneManager.LoadScene(1);

    }

    public void Challenge(){

    }

}
