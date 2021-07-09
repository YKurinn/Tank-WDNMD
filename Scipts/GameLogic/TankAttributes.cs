using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*该脚本挂载于坦克上*/
public class TankAttributes : MonoBehaviour
{
    public float health;//坦克生命值
    public float damage;//炮弹基础伤害
    public float bulletCount;//剩余炮弹数

    public bool isDead()
    {
        return (health <= 0);
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }

    public float GetDamage()
    {
        return damage;
    }
    
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            //死亡事件实现
        }
    }
}
