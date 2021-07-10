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

    //碰撞开始  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageValue = collision.gameObject.GetComponent<BulletAttributes>().GetDamage();//获得子弹伤害
            transform.GetComponent<TankAttributes>().SetHealth(transform.GetComponent<TankAttributes>().GetHealth() - damageValue);//修改坦克血量
            //Destroy(collision.gameObject);//移除子弹
        }
    }

    //碰撞中  
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
        }
    }

    //碰撞结束  
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"    )
        {
            
        }
    }  

}
