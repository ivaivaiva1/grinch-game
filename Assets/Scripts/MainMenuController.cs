using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button PlayButton;
    public Button CreditsButton;
    public GameObject CreditsPanel;


    
    public void Play()
    {

    }
    public void ShowCredits()
    {
       CreditsPanel.SetActive(true);
       PlayButton.gameObject.SetActive(false);
       CreditsButton.gameObject.SetActive(false);
    }
    public void HideCredits()
    {
       CreditsPanel.SetActive(false);
       PlayButton.gameObject.SetActive(true);
       CreditsButton.gameObject.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
