using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool right = true;
    [SerializeField] GameObject controller;
    //[SerializeField] bool isGrounded = true;

    [SerializeField] AudioSource pop;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("GameController");
        
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        if (GetComponent<AudioSource>() == null)
            pop = GetComponent<AudioSource>();

        ani = GetComponent<Animator>();

        //GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        Physics2D.IgnoreLayerCollision(2,2);

        InvokeRepeating("Large", 5.0f, 5.0f);

    }

    void Large()
    {
        this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.position.x > 8){
            right = false;
        }

        if(transform.position.x < -8){
            right = true;
        }
        direction();

        if(transform.localScale.x > 0.8f){
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            ani.SetTrigger("popB");

            if(controller.GetComponent<ScoreManager>().Life() == 1)
            SceneManager.LoadScene(4);
            else{
                controller.GetComponent<ScoreManager>().LifeLoss();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            //StartCoroutine(WaitForSceneLoad());
        }
        
    }

    //private IEnumerator WaitForSceneLoad() {
        //yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    //}

    void direction(){
        if(right){
            transform.Translate(2* Time.deltaTime * movement , 0,0);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * movement , 0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pin")
        {
            controller.GetComponent<ScoreManager>().AddPoints();
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            //pop.Play();
            ani.SetTrigger("popB");
            Destroy(gameObject, 0.5f);
        }

    }
}
