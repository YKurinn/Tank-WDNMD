using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject current;
    public GameObject destination;
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
        current.SetActive(false);
        destination.SetActive(true);
    }
}
