using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mainmenu;
    public GameObject chooseModeButtons;
    public GameObject settingsMenuButtons;
    public GameObject helpCanvas;
    //public GameObject map1;
    void Start()
    {
        //Mainmenu.SetActive(false);
        chooseModeButtons.SetActive(false);
        settingsMenuButtons.SetActive(false);
        helpCanvas.SetActive(false);
        //map1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
