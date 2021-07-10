using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class AIController : MonoBehaviour
{

    public Transform NPCCamera;
    public Transform tower;
    public Transform cannon;

    private float NPCMoveTime;
    private float blockTime;//NPC以某一速度移动
    private float motor;
    private float steering;
    private float random_m;//获取的随机motor增量
    private float random_s;//获取的随机steering增量
    private Vector3 NPCPrevious;//NPC上一次移动的初始位置
    private bool IsFirstBlock;//第一次位置相同阻塞
    private bool IsMoreBlock;//多次阻塞
    RaycastHit hit;
    public Transform player;

    public List<MPC_AxleInfo> axleInfos; // 关于每个轴的信息
    Transform Wheel;
    public Transform CenterOfMass;

    

    //视角中是否有玩家
    bool Isview( Transform player,Transform AI ,float cos_angle){
        GetComponent<Camera>().WorldToScreenPoint(player.position);
        Vector3 dir = (player.position - AI.position).normalized;
        float dot = Vector3.Dot(dir , AI.forward);
        if (dot > cos_angle)  return true;
        return false;
    }

    void Start()
    {
        IsFirstBlock = false;
        GetComponent<Camera>().enabled = false;

        NPCMoveTime = Time.time;
        motor = UnityEngine.Random.Range(-1, 3);
        steering = UnityEngine.Random.Range(-1, 1);

        Wheel = transform.Find("Wheel");
        GetComponent<Rigidbody>().centerOfMass = CenterOfMass.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NPCCamera.transform.LookAt(player);
        Vector3 dir = (player.position - NPCCamera.position).normalized;
        Physics.Raycast(NPCCamera.position, dir, out hit);
        if (Vector3.Distance(player.position,transform.position)>50)
        {
            //如果卡着超过8秒，当前没阻塞，则置为第一次阻塞；否则置为第二次
            if (Vector3.Distance(transform.position, NPCPrevious) < 0.1)
            {
                if(!IsFirstBlock)
                IsFirstBlock = Time.time - blockTime > 8 ? true : false;
                else
                IsMoreBlock = Time.time - blockTime > 8 ? true : false;
                IsFirstBlock = IsMoreBlock ? false : true;
            }
            //检测到出了阻塞点，则重置计算时间,阻塞也消失
            else
            {
                blockTime = Time.time;
                IsFirstBlock = false;
                IsMoreBlock = false;
            }

            //如果到了移动时间，但第一次阻塞，改变马力方向即可
            if (IsFirstBlock && Time.time > NPCMoveTime && motor != 0)
            {
                random_m = -random_m;
                random_s = 0;
                NPCMoveTime += 8;
            }
            //到了移动时间，为第二次阻塞，重置位置
            else if (IsMoreBlock && motor != 0 && Time.time > NPCMoveTime)
            {
                transform.position = new Vector3(transform.position.x + 3 ,transform.position.y + 5,transform.position.z);
                transform.forward = new Vector3(transform.forward.x,0,transform.forward.z);
                IsFirstBlock = false;
            }
            //到时间没有阻塞，正常运行
            else if (!IsFirstBlock && !IsMoreBlock && Time.time > NPCMoveTime)
            {
                random_m = UnityEngine.Random.Range(-1, 5) * 100;
                if(random_m != 0) random_m = random_m / Mathf.Abs(random_m);
                random_s = UnityEngine.Random.Range(-5, 5);
                if(random_s != 0)  random_s = random_s / Mathf.Abs(random_s);
                if (Mathf.Abs(random_s) < 3) random_s = 0;
                NPCMoveTime += 2;
                NPCPrevious = transform.position;
            }
            //取范围内的改变后的motor值和steering值
                motor = Mathf.Clamp(motor + random_m *100, -2000, 2000);
                Debug.Log(motor);
                steering = Mathf.Clamp(steering + random_s *100, -30, 30);

            foreach (MPC_AxleInfo axleInfo in axleInfos)
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
                    //Debug.Log(motor);
                }
                if (axleInfos[1] != null && axleInfo == axleInfos[1])
                {
                    WheelROotation(axleInfos[1].leftWheel);
                }
            }
           // Debug.Log(0);
        }
        else
        {
           /* foreach (MPC_AxleInfo axleInfo in axleInfos)
            {
                //if (axleInfo.steering)
                //{
                //    axleInfo.leftWheel.steerAngle = 0;
                //    axleInfo.rightWheel.steerAngle = 0;
                //}
                //if (axleInfo.motor)
                //{
                //    axleInfo.leftWheel.motorTorque = 0;
                //    axleInfo.rightWheel.motorTorque = 0;
                //}
                //if (axleInfos[1] != null && axleInfo == axleInfos[1])
                //{
                //    WheelROotation(axleInfos[1].leftWheel);
                //}
            }*/
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Isview(player, cannon,0.99f)&& transform.GetChild(3).GetChild(0).GetComponent<AIShooting>().isShootingReady())
            {
                transform.GetChild(3).GetChild(0).GetComponent<AIShooting>().Shoot();
            }
            float horizentalAngleDifference = NPCCamera.transform.rotation.eulerAngles.y - tower.transform.rotation.eulerAngles.y;
            if ((horizentalAngleDifference < 180f && horizentalAngleDifference > 0f) || horizentalAngleDifference < -180f)
            {
                tower.transform.Rotate(0, 0.5f, 0, Space.Self);
            }
            if ((horizentalAngleDifference < -0.51f && horizentalAngleDifference > -174.9f) || horizentalAngleDifference > 185.1f)
            {
                tower.transform.Rotate(0, -0.5f, 0, Space.Self);
            }
            float verticalAngleDifference = NPCCamera.transform.rotation.eulerAngles.x - cannon.transform.rotation.eulerAngles.x;
            if ((verticalAngleDifference < 180f && verticalAngleDifference > 0f) || verticalAngleDifference < -180f)
            {
                cannon.transform.Rotate(0.1f, 0, 0, Space.Self);
            }
            if ((verticalAngleDifference < -0.11f && verticalAngleDifference > -178.9f) || verticalAngleDifference > 181.1f)
            {
                cannon.transform.Rotate(-0.1f, 0, 0, Space.Self);
            }
            //Debug.Log(1);
            NPCMoveTime = Time.time;
            blockTime = Time.time;
        }

    }
    void WheelROotation(WheelCollider collider)
    {
        if (Wheel == null)
            return;
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        foreach (Transform wheel in Wheel)
        {
            wheel.rotation = rotation;
        }
    }
}
[System.Serializable]
public class MPC_AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // 此车轮是否连接到电机？
    public bool steering; // 此车轮是否施加转向角？
}
