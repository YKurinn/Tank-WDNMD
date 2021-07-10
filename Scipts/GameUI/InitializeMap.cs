using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeMap : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject finish;
    public GameObject player;
    public GameObject enemy;
    public GameObject pauseButtons;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            pauseButtons.SetActive(true);
            finish.SetActive(false);
        }
        if (player.GetComponent<TankAttributes>().isDead())
        {
            Cursor.visible = true;
            pauseCanvas.SetActive(true);
            pauseButtons.SetActive(false);
            finish.SetActive(true);
            finish.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (enemy.GetComponent<TankAttributes>().isDead())
        {
            Cursor.visible = true;
            pauseCanvas.SetActive(true);
            pauseButtons.SetActive(false);
            finish.SetActive(true);
            finish.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
