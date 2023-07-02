using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{

    private Rigidbody2D rb;
    public float rotate;
    public Vector3 v3Velocity;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        //Vector3 vel = rb.velocity;
        //rotate = vel;
        v3Velocity = rb.velocity; 
        rotate = v3Velocity.y;
        transform.Rotate(new Vector3(0, 0, rotate)); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Presente"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("PerderM"))
        {
            Destroy(gameObject);
        }
    }

}
