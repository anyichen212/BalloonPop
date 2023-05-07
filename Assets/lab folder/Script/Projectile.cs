using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 7f;
    [SerializeField] Rigidbody2D rigid;

    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
            transform.Rotate(0,0,-152);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 2* Time.deltaTime * Speed,0, Space.World);
        //transform.position += transform.up*Time.deltaTime * Speed;

        if(transform.position.y > 8){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "balloon")
        Destroy(gameObject);
    }
}
