using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator dog;
    public Animator santa;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dog");
        StartCoroutine("Santa");
    }

     IEnumerator Dog()
   {
       yield return new WaitForSeconds(Random.Range(3f,7f));
       dog.SetTrigger("dogANIM");
       Doger();
   } 
   IEnumerator Santa()
   {
       yield return new WaitForSeconds(Random.Range(20f,25f));
       santa.SetTrigger("santaANIM");
       Santer();
   }

    
   public void Doger()
   {
      print("Doger");
      dog.SetTrigger("dogIDLE");
      StartCoroutine("Dog");
   }

   public void Santer()
   {
      print("Santer");
      santa.SetTrigger("santaIDLE");
      StartCoroutine("Santa");
   }




}
