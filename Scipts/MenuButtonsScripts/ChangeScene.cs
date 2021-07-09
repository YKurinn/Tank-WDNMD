using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChangeScene : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string sceneName;
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
        Application.LoadLevel(sceneName);
    }
}
