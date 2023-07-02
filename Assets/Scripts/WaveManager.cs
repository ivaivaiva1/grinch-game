using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public bool spawn0 = true;
    public bool spawn1 = true;
    public bool spawn2 = true;
    public bool spawn3 = true;
    public bool spawn4 = true;


    public static int enemiesAlive;
    public int currentRound;
    public GameObject[] enemiesGO;
    public GameObject[] spawnPoints;
    public int[] enemiesToSpawn;
    public int lastSpawn;
    public int lastGift;
    public int giftsPerRound = -1;
    public int giftsSpawned;
    private float reSpawnTime;
    public Text roundText;
    public Text doomText;
    public GameObject doomPanel;

    void Start() {
        Lancador.shootCD = 2f;
        ScoreManager.score = 0;
        currentRound = 1;
        nextRound();
    }

    //Faz o Presente ser spawnado em lugar aleatório
    void randomSpawn()
    {
        lastSpawn = Random.Range(0,5);
        if(lastSpawn == 0 & spawn0 == false)
        {
            randomSpawn();
        } else
        if(lastSpawn == 1 & spawn1 == false)
        {
            randomSpawn();
        } else
        if(lastSpawn == 2 & spawn2 == false)
        {
            randomSpawn();
        } else
        if(lastSpawn == 3 & spawn3 == false)
        {
            randomSpawn();
        }
        if(lastSpawn == 4 & spawn4 == false)
        {
            randomSpawn();
        }    
    }

    IEnumerator callText()
    {
        yield return new WaitForSeconds(5f);
        roundText.GetComponent<Text>() .enabled = false;
    }
    IEnumerator callDoom()
    {
        yield return new WaitForSeconds(5f);
        doomText.GetComponent<Text>() .enabled = false;
    }

    IEnumerator callRound()
    {
        yield return new WaitForSeconds(2f);
        nextRound();
    }

    void spawnGifts()
    {   
        if(giftsSpawned == giftsPerRound)
        {
            if(LifeManager.isDeath == true){
                
                return;
            } else
            currentRound++;
            if(currentRound != 16)
            {
            roundText.text = "Round " + currentRound.ToString();
            roundText.GetComponent<Text>() .enabled = true;
            StartCoroutine("callRound");  
            StartCoroutine("callText");     
            return;    
            } else
            doomPanel.SetActive(true);
            doomText.GetComponent<Text>() .enabled = true;
            StartCoroutine("callRound"); 
            StartCoroutine("callDoom");  
            return;            
        }
        randomGifts();
        randomSpawn();
            if(lastSpawn == 0)
            {
                Instantiate(enemiesGO[lastGift],spawnPoints[lastSpawn].transform.position, Quaternion.identity);
                enemiesToSpawn[lastGift]--;
                spawn0 = false;
                enemiesAlive++;
                giftsSpawned++;
                StartCoroutine("spawn0C");
                StartCoroutine("reSpawn");
            }
            if(lastSpawn == 1)
            {
                Instantiate(enemiesGO[lastGift],spawnPoints[lastSpawn].transform.position, Quaternion.identity);
                enemiesToSpawn[lastGift]--;
                spawn1 = false;
                enemiesAlive++;
                giftsSpawned++;
                StartCoroutine("spawn1C");
                StartCoroutine("reSpawn");
            }
            if(lastSpawn == 2)
            {
                Instantiate(enemiesGO[lastGift],spawnPoints[lastSpawn].transform.position, Quaternion.identity);
                enemiesToSpawn[lastGift]--;
                spawn2 = false;
                enemiesAlive++;
                giftsSpawned++;
                StartCoroutine("spawn2C");
                StartCoroutine("reSpawn");               
            }
            if(lastSpawn == 3)
            {
                Instantiate(enemiesGO[lastGift],spawnPoints[lastSpawn].transform.position, Quaternion.identity);
                enemiesToSpawn[lastGift]--;
                spawn3 = false;
                enemiesAlive++;
                giftsSpawned++;
                StartCoroutine("spawn3C");
                StartCoroutine("reSpawn");
            }
            if(lastSpawn == 4)
            {
                Instantiate(enemiesGO[lastGift],spawnPoints[lastSpawn].transform.position, Quaternion.identity);
                enemiesToSpawn[lastGift]--;
                spawn4 = false;
                enemiesAlive++;
                giftsSpawned++;
                StartCoroutine("spawn4C");
                StartCoroutine("reSpawn");
            }
    }

    IEnumerator reSpawn()
    {
        yield return new WaitForSeconds (3.5f - reSpawnTime);
        spawnGifts();
    }

    IEnumerator spawn0C(){
        yield return new WaitForSeconds (5f);
        spawn0 = true;
    }
    
    IEnumerator spawn1C(){
        yield return new WaitForSeconds (5f);
        spawn1 = true;
    }
    
    IEnumerator spawn2C(){
        yield return new WaitForSeconds (5f);
        spawn2 = true;
    }
    
    IEnumerator spawn3C(){
        yield return new WaitForSeconds (5f);
        spawn3 = true;
    }
    
    IEnumerator spawn4C(){
        yield return new WaitForSeconds (5f);
        spawn4 = true;
    }
   
    // Rounds e Presentes;     -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------------------------------

    //Faz o Presente ser aleatório
    void randomGifts()
    {
        lastGift = Random.Range(0,11);
        if(enemiesToSpawn[lastGift] == 0){
            randomGifts();
        }
        // if(lastGift == 0 & enemiesToSpawn[0] == 0)
        // {
        //    randomGifts();
        // } else
        // if(lastGift == 1 & enemiesToSpawn[1] == 0)
        // {
        //    randomGifts();
        // } else
        // if(lastGift == 2 & enemiesToSpawn[2] == 0)
        // {
        //    randomGifts();
        // } else
        // if(lastGift == 3 & enemiesToSpawn[3] == 0)
        // {
        //    randomGifts();
        // } else
        // if(lastGift == 4 & enemiesToSpawn[4] == 0)
        // {
        //    randomGifts();
        // } else 
        // if(lastGift == 5 & enemiesToSpawn[5] == 0)
        // {
        //    randomGifts();
        // } else 
        // if(lastGift == 6 & enemiesToSpawn[6] == 0)
        // {
        //    randomGifts();
        // } else 
        // if(lastGift == 7 & enemiesToSpawn[7] == 0)
        // {
        //    randomGifts();
        // } else 
        // if(lastGift == 8 & enemiesToSpawn[8] == 0)
        // {
        //    randomGifts();
        // } else 
        // if(lastGift == 9 & enemiesToSpawn[9] == 0)
        // {
        //    randomGifts();
        // }      
    }
    
    

    void nextRound()
    {
        switch (currentRound)
        {
          case 1:
            enemiesToSpawn[0] = 3;
            enemiesToSpawn[1] = 3;
            break;           
          case 2:
            enemiesToSpawn[0] = 3;
            enemiesToSpawn[1] = 3;
            enemiesToSpawn[2] = 1;
            break;
          case 3:
            enemiesToSpawn[0] = 2;
            enemiesToSpawn[1] = 3;
            enemiesToSpawn[2] = 3;
            Lancador.shootCD = Lancador.shootCD - 0.1f;
            break;
          case 4:
            enemiesToSpawn[0] = 2;
            enemiesToSpawn[1] = 3;
            enemiesToSpawn[2] = 3;
            enemiesToSpawn[3] = 2;
            enemiesToSpawn[10] = 1;
            Lancador.shootCD = Lancador.shootCD - 0.3f;
            break;
          case 5:
            enemiesToSpawn[0] = 1;
            enemiesToSpawn[1] = 1;
            enemiesToSpawn[2] = 1;
            enemiesToSpawn[3] = 1;
            enemiesToSpawn[4] = 1;
            Lancador.shootCD = Lancador.shootCD - 0.1f;    
            reSpawnTime =  0.5f; 
            break;
          case 6:
            enemiesToSpawn[0] = 3;
            enemiesToSpawn[1] = 3;
            enemiesToSpawn[2] = 4;
            enemiesToSpawn[3] = 2;
            enemiesToSpawn[4] = 2;
            Lancador.shootCD = Lancador.shootCD - 0.3f;
            LifeManager.lifes++;
            FindObjectOfType<LifeManager>().UpdateLifeHud();
            break;
          case 7:
            enemiesToSpawn[0] = 2;
            enemiesToSpawn[1] = 2;
            enemiesToSpawn[2] = 2;
            enemiesToSpawn[3] = 3;
            enemiesToSpawn[4] = 3;
            enemiesToSpawn[5] = 1;
            enemiesToSpawn[6] = 1;
            Lancador.shootCD = Lancador.shootCD - 0.1f;
            break;
          case 8:
            enemiesToSpawn[0] = 1;
            enemiesToSpawn[1] = 2;
            enemiesToSpawn[2] = 2;
            enemiesToSpawn[3] = 2;
            enemiesToSpawn[4] = 2;
            enemiesToSpawn[5] = 5;
            enemiesToSpawn[6] = 2;
            enemiesToSpawn[7] = 1;
            enemiesToSpawn[10] = 1;
            Lancador.shootCD = Lancador.shootCD - 0.1f;  
            reSpawnTime = reSpawnTime + 0.5f; 
            LifeManager.lifes++;
            FindObjectOfType<LifeManager>().UpdateLifeHud();
            break;
          case 9:
            enemiesToSpawn[0] = 1;
            enemiesToSpawn[1] = 3;
            enemiesToSpawn[2] = 1;
            enemiesToSpawn[3] = 3;
            enemiesToSpawn[4] = 2;
            enemiesToSpawn[5] = 3;
            enemiesToSpawn[6] = 3;
            enemiesToSpawn[7] = 3;
            enemiesToSpawn[10] = 2;
            break;
          case 10:
            enemiesToSpawn[5] = 2;
            enemiesToSpawn[6] = 2;
            enemiesToSpawn[7] = 2;
            enemiesToSpawn[8] = 2;
            enemiesToSpawn[9] = 2;
            break;  
          case 11:
            enemiesToSpawn[3] = 1;
            enemiesToSpawn[4] = 1;
            enemiesToSpawn[5] = 1;
            enemiesToSpawn[6] = 1;
            enemiesToSpawn[7] = 1;
            enemiesToSpawn[8] = 1;
            enemiesToSpawn[9] = 1;
            enemiesToSpawn[10] = 2;
            Lancador.shootCD = Lancador.shootCD - 0.25f; 
            ParachuteComponent.roundMultiplier = 1.2f;
            reSpawnTime = reSpawnTime + 0.5f; 
            LifeManager.lifes++;
            FindObjectOfType<LifeManager>().UpdateLifeHud(); 
            break;    
         case 12:
            enemiesToSpawn[1] = 2;
            enemiesToSpawn[3] = 2;
            enemiesToSpawn[4] = 2;
            enemiesToSpawn[5] = 2;
            enemiesToSpawn[6] = 5;
            enemiesToSpawn[7] = 2;
            enemiesToSpawn[8] = 3;
            enemiesToSpawn[9] = 3;
            Lancador.shootCD = Lancador.shootCD - 0.25f; 
            reSpawnTime = reSpawnTime + 0.5f; 
            break;    
          case 13:
            enemiesToSpawn[0] = 1;
            enemiesToSpawn[1] = 1;
            enemiesToSpawn[2] = 1;
            enemiesToSpawn[3] = 2;
            enemiesToSpawn[4] = 2;
            enemiesToSpawn[5] = 2;
            enemiesToSpawn[6] = 2;
            enemiesToSpawn[7] = 2;
            enemiesToSpawn[8] = 5;
            enemiesToSpawn[9] = 5;
            break;    
          case 14:
            enemiesToSpawn[5] = 1;
            enemiesToSpawn[6] = 1;
            enemiesToSpawn[7] = 1;
            enemiesToSpawn[8] = 5;
            enemiesToSpawn[9] = 5;
            enemiesToSpawn[10] = 3;
            LifeManager.lifes++;
            FindObjectOfType<LifeManager>().UpdateLifeHud(); 
            break;   
         case 15:
            enemiesToSpawn[0] = 1;
            enemiesToSpawn[1] = 1;
            enemiesToSpawn[2] = 1;
            enemiesToSpawn[3] = 1;
            enemiesToSpawn[4] = 1;
            enemiesToSpawn[5] = 3;
            enemiesToSpawn[6] = 3;
            enemiesToSpawn[7] = 3;
            enemiesToSpawn[8] = 5;
            enemiesToSpawn[9] = 5;
            enemiesToSpawn[10] = 5;
            //Lancador.shootCD = Lancador.shootCD - 1.5f; 
            //reSpawnTime = 1.5f;    
            break;  
        case 16:
            enemiesToSpawn[0] = 100;
            enemiesToSpawn[1] = 100;
            enemiesToSpawn[2] = 100;
            enemiesToSpawn[3] = 100;
            enemiesToSpawn[4] = 100;
            enemiesToSpawn[5] = 100;
            enemiesToSpawn[6] = 100;
            enemiesToSpawn[7] = 100;
            enemiesToSpawn[8] = 100;
            enemiesToSpawn[9] = 100;
            enemiesToSpawn[10] = 100;
            ParachuteComponent.finalSpeed = -0.04f;
            ParachuteComponent.roundMultiplier = 1.5f;
            reSpawnTime = reSpawnTime + 0.5f; 
            LifeManager.lifes++;
            LifeManager.lifes++;
            FindObjectOfType<LifeManager>().UpdateLifeHud(); 
            break;     
        }
        updateGiftsPerRound(currentRound);
        giftsSpawned = 0;
        spawnGifts();
    }
    

     void updateGiftsPerRound(int round)
     {
         giftsPerRound = 0;
         for(int i = 0; i < enemiesToSpawn.Length; i++)
         {
             giftsPerRound += enemiesToSpawn[i];
         }
     }




  
}
