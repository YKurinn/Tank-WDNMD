using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChangeCanvas : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject currentCanvas;
    public GameObject destinationCanvas;
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
        currentCanvas.SetActive(false);
        destinationCanvas.SetActive(true);
    }
}
