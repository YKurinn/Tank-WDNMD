using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public GameObject viewCamera;
    //public GameObject normalCamera;
    public GameObject aimCamera;
    public GameObject cannonTower;
    public GameObject cannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            return;
        }
        GameObject currentCamera;
        if (Input.GetKey(KeyCode.Space))
        {
            currentCamera = aimCamera;
            //normalCamera.SetActive(false);
            //normalCamera.GetComponent<Camera>().enabled = false;
            viewCamera.GetComponent<Camera>().enabled = false;
        }
        else
        {
            currentCamera = viewCamera;
            //aimCamera.SetActive(false);
            aimCamera.GetComponent<Camera>().enabled = false;
        }
        //currentCamera.SetActive(true);
        currentCamera.GetComponent<Camera>().enabled = true;


        float horizentalAngleDifference = viewCamera.transform.rotation.eulerAngles.y - cannonTower.transform.rotation.eulerAngles.y;
        if ((horizentalAngleDifference < 180f && horizentalAngleDifference > 0f )|| horizentalAngleDifference < -180f)
        {
            cannonTower.transform.Rotate(0, 0.5f, 0, Space.Self);
        }
        if ((horizentalAngleDifference < -0.51f && horizentalAngleDifference > -174.9f )|| horizentalAngleDifference > 185.1f)
        {
            cannonTower.transform.Rotate(0, -0.5f, 0, Space.Self);
        }
        float verticalAngleDifference = (viewCamera.transform.rotation.eulerAngles.x - cannon.transform.rotation.eulerAngles.x)%360f;
        
        if ((verticalAngleDifference <180f&& verticalAngleDifference>0f )|| verticalAngleDifference<-180f)
        {
            cannon.transform.Rotate(0.1f, 0, 0, Space.Self);
        }
        if ((verticalAngleDifference < -0.11f&& verticalAngleDifference>-178.9f)|| verticalAngleDifference>181.1f)
        {
            cannon.transform.Rotate(-0.1f, 0, 0, Space.Self);
        }
        //Debug
    }
}
