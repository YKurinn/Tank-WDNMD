using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed;
    public List<AxleInfo> axleInfos; // 关于每个轴的信息
    public float maxMotorTorque; // 电机可对车轮施加的最大扭矩
    public float maxSteeringAngle; // 车轮的最大转向角
    Transform Wheel;
    public Transform CenterOfMass;
    // Start is called before the first frame update
    void Start()
    {
        Wheel = transform.Find("Wheel");
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            if(axleInfos[1]!=null && axleInfo== axleInfos[1])
            {
                WheelROotation(axleInfos[1].leftWheel);
            }
        }
    }
    void WheelROotation(WheelCollider collider)
    {
        if (Wheel == null)
            return;
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        foreach(Transform wheel in Wheel)
        {
            wheel.rotation = rotation;
        }
    }


}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // 此车轮是否连接到电机？
    public bool steering; // 此车轮是否施加转向角？
}
