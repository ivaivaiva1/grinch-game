using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

    public static int lifes;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject gameOverPanel;
    public static bool isDeath = false;



    void Start()
    {
        isDeath = false;
        lifes = 3;   
    }
    
    public void Death()
    {
        if (lifes <= 0)
        {
           isDeath = true;
           gameOverPanel.SetActive(true);
        }
    }
     

    // Update is called once per frame
    public void UpdateLifeHud() 
    {
        if (lifes >3){
            lifes = 3;
        }
        if(lifes == 3)
        {
            Life3.GetComponent<SpriteRenderer>() .enabled = true;   
        } else
        if(lifes == 2)
        {
            Life3.GetComponent<SpriteRenderer>() .enabled = false;   
            Life2.GetComponent<SpriteRenderer>() .enabled = true;  
        } else
         if(lifes == 1)
        {
            Life3.GetComponent<SpriteRenderer>() .enabled = false;   
            Life2.GetComponent<SpriteRenderer>() .enabled = false;  
            Life1.GetComponent<SpriteRenderer>() .enabled = true;  
        } else
          if(lifes == 0)
        {
            Life3.GetComponent<SpriteRenderer>() .enabled = false;   
            Life2.GetComponent<SpriteRenderer>() .enabled = false;  
            Life1.GetComponent<SpriteRenderer>() .enabled = false;  
        }

    }
    
}
