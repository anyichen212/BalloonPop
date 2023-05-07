using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void restart(){
        SceneManager.LoadScene(0);
    }

    public void end(){
        SceneManager.LoadScene(4);
    }
}
