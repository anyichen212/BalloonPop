using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int highScore = 0;
    //const int DEFAULT_POINTS = 1;
    //const int SCORE_THRESHOLD = 5;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI lifeTxt;
    int life;
    //[SerializeField] TextMeshProUGUI[] scoreTexts;

    int SCORE_THRESHOLD;

    //[SerializeField] Text sceneTxt;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        lifeTxt.text = life.ToString();
        score = PersistentData.Instance.GetScore();
        highScore = GetComponent<SaveHighScores>().TopScore();
        scoreTxt.text = "SCORE : " + score;
        highScoreTxt.text = "TOP SCORE : " + highScore;

        level = SceneManager.GetActiveScene().buildIndex;
        SCORE_THRESHOLD = level*level;
    }


    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        Destroy(gameObject);

        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            //GetComponent<SaveHighScores>().enabled = true;
            //GetComponent<SaveHighScores>().Top();

            if(transform.GetChild(0).gameObject.activeSelf){
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        
    }


    public void AddPoints()
    {
        score++;
        PersistentData.Instance.SetScore(score);
        scoreTxt.text = "SCORE : " + score;

        if (score >= SCORE_THRESHOLD){
            level++;
            SCORE_THRESHOLD = level*level;
            AdvanceLevel();
        }

    }

    public void AdvanceLevel()
    {
        //Debug.Log(level);
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
     
    }

    public void LifeLoss(){
        life--;
        lifeTxt.text = life.ToString();

        if(life == 0)
            SceneManager.LoadScene(4);
    }

    public int Life(){
        return life;
    }
}
