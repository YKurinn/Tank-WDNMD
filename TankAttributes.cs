using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�ýű�������̹����*/
public class TankAttributes : MonoBehaviour
{
    public float health;//̹������ֵ
    public float damage;//�ڵ������˺�
    public float bulletCount;//ʣ���ڵ���

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
            //�����¼�ʵ��
        }
    }
}
