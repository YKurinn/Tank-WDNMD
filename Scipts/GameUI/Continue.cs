using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Continue : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
}
