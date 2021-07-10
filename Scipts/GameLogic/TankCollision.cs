using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour
{
    private float damageValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ײ��ʼ  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageValue = collision.gameObject.GetComponent<BulletAttributes>().GetDamage();//����ӵ��˺�
            transform.GetComponent<TankAttributes>().SetHealth(transform.GetComponent<TankAttributes>().GetHealth() - damageValue);//�޸�̹��Ѫ��
            //Destroy(collision.gameObject);//�Ƴ��ӵ�
        }
    }

    //��ײ��  
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
        }
    }

    //��ײ����  
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"    )
        {
            
        }
    }  

}
