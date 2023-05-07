using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool right = true;
    [SerializeField] AudioSource buzz;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(2,2);
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
    }

    void direction()
    {
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
            buzz.Play();
        }

    }
}
