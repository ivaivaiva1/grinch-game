using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancador : MonoBehaviour
{

    public GameObject[] tiros;
    public float força = 17;
    public float distanciaMax = 1;
    Vector3 mousePosition;
    GameObject instanciaTemp;
    bool instanciou = false;
    public static float shootCD = 2f;
    public bool canShoot = true;
    public GameObject shootOBG;
    public int randomSpawn;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        randomSpawn = Random.Range(0,6);
        if (Input.GetMouseButton(0) & canShoot == true)
        {
            anim.SetBool("shooting",true);
            mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
            mousePosition.z = transform.position.z;
            if (instanciou == false & Vector3.Distance(transform.position, mousePosition) < distanciaMax)
            {            
                instanciou = true;
                instanciaTemp = Instantiate(tiros[randomSpawn], mousePosition, transform.rotation) as GameObject;
                instanciaTemp.GetComponent<Collider2D> ().enabled = false;
                instanciaTemp.GetComponent<Rigidbody2D>().isKinematic = true;             
            } 
            //instanciaTemp.transform.position = transform.position + (mousePosition - transform.position).normalized * distanciaMax;
            if(instanciou == true)
            {
                if(Vector3.Distance(transform.position, mousePosition) < distanciaMax)
                {
                   instanciaTemp.transform.position = mousePosition;
                } else 
                instanciaTemp.transform.position = transform.position + (mousePosition - transform.position).normalized * distanciaMax;
            }
            


        
        }
        if(Input.GetMouseButtonUp (0) && instanciou == true)
        {
            GetComponent<AudioSource>().Play();
            anim.SetBool("shooting",false);
            canShoot = false;
            StartCoroutine("reShoot");
            Vector3 direcao = transform.position - instanciaTemp.transform.position;
            instanciaTemp.GetComponent<Collider2D> ().enabled = true;
            instanciaTemp.GetComponent<Rigidbody2D>().isKinematic = false;
            instanciaTemp.GetComponent<Rigidbody2D>().AddForce(direcao * força, ForceMode2D.Impulse);
            instanciou = false;
            instanciaTemp = null;
        }
    
    if(canShoot == false)
    {
        shootOBG.SetActive(false);
    } else
    if(canShoot == true)
    {
        shootOBG.SetActive(true);
    }  

    }

   IEnumerator reShoot()
   {
       yield return new WaitForSeconds(shootCD);
       canShoot = true;
   }

    
}
