using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeMap : MonoBehaviour
{
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
        if (pauseCanvas.active)
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                Time.timeScale = 1;
                pauseCanvas.SetActive(false);
            }
        }
    }
}
