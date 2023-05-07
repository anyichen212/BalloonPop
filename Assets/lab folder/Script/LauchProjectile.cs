using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauchProjectile : MonoBehaviour
{
    public GameObject projectile;
   public float launchVelocity = 700f;
   public Transform Pins;
   [SerializeField] AudioSource whoosh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            whoosh.Play();
            GameObject pin = Instantiate(projectile, Pins.position, transform.rotation, Pins);
            pin.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));

        }
    }
}
