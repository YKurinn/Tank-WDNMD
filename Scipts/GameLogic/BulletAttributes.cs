using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�ýű�������أ�ͨ�������ű���̬��ӵ��ڵ���*/
public class BulletAttributes : MonoBehaviour
{
    public float damage;//�ڵ��˺�

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(transform.gameObject);//�Ƴ��ӵ�
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
