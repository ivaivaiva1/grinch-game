using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public static GameManager gm;
    public GameObject creditsUI;
    public GameObject city; 
    


    private void Awake() {
        if(gm == null)
        {
            gm = this;
        } else
        if(gm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lancador.shootCD == 2f)
        {
           transform.GetComponent<AudioSource>().pitch = 0.9f;
        } else
        if(Lancador.shootCD <= 1.7f)
        {
           transform.GetComponent<AudioSource>().pitch = 1f;
        } else
        if(Lancador.shootCD <= 1.3f)
        {
           transform.GetComponent<AudioSource>().pitch = 1.05f;
        } else
        if(Lancador.shootCD <= 1f)
        {
           transform.GetComponent<AudioSource>().pitch = 1.1f;
        } 
         if(Lancador.shootCD <= 0.7f)
        {
           transform.GetComponent<AudioSource>().pitch = 1.15f;
        } else
         if(Lancador.shootCD <= 0.5f)
        {
           transform.GetComponent<AudioSource>().pitch = 1.25f;
        }
    }

    public void StartRun()
    { 
       SceneManager.LoadScene("Game");
    }

    public void EndRun()
    { 
       SceneManager.LoadScene("Menu");
    }

    public void ShowCredits()
    {
       creditsUI.SetActive(true);
       city.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.07843138f);
    }
    public void HideCredits()
    {
       creditsUI.SetActive(false);
       city.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }





}
