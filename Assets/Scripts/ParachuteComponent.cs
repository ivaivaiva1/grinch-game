using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteComponent : MonoBehaviour
{

    public float fallSpeed;
    public float animationSpeed;
    private Animator anim;
    public int Pontos; 
    public static float roundMultiplier = 1;
    public static float finalSpeed = 0;
    public GameObject Paraquedas;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = animationSpeed;
    }
    
    private void Start() 
    {       
        if(finalSpeed < 0)
        {
           fallSpeed = finalSpeed;
        } 
        fallSpeed = fallSpeed * roundMultiplier;
    }

    void FixedUpdate()
    {
        transform.Translate(0, fallSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Municao"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;      
            Paraquedas.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>(). enabled = false;   
            ScoreManager.score += Pontos;
            WaveManager.enemiesAlive--;         
            Destroy(gameObject, 1);
        }
        if (col.gameObject.CompareTag("Perder"))
        {   
            LifeManager.lifes = LifeManager.lifes -1;
            WaveManager.enemiesAlive--;
            FindObjectOfType<LifeManager>().UpdateLifeHud();
            FindObjectOfType<LifeManager>().Death();
            Destroy(gameObject);
        }
    }

}
