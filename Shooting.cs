using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�ýű��������ڹ���*/
public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;//�ڵ�Ԥ����
    GameObject bullet;//�ڵ�
    public float bulletVelocity;//�ڵ�����
    public bool gravityActive;//�ڵ��Ƿ�ʹ������
    public float reloadTime;//װ��ʱ��
    float timeSinceLastShoot;//�ϴη���ʱ��

    //���
    private void Shoot()
    {
        bullet = GameObject.Instantiate(bulletPrefab, transform.position+3f*transform.forward, transform.rotation);//�����ڵ�ģ��
        bullet.AddComponent<BulletAttributes>();//���ڵ���ӽű�
        bullet.GetComponent<BulletAttributes>().SetDamage(transform.parent.parent.GetComponent<TankAttributes>().GetDamage());//�����ڵ��˺�
        bullet.AddComponent<BoxCollider>();//�����ײ��
        bullet.AddComponent<Rigidbody>();//��Ӹ���
        bullet.GetComponent<Rigidbody>().useGravity = gravityActive;//��������
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;//���ó���
        transform.parent.parent.GetComponent<TankAttributes>().bulletCount--;//�ڵ���-1
        timeSinceLastShoot = Time.time;//�����ϴη���ʱ��
    }

    private bool isShootingReady()
    {
        return (transform.parent.parent.GetComponent<TankAttributes>().bulletCount > 0) && (Time.time - timeSinceLastShoot > reloadTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&isShootingReady())
        {
            Shoot();
        }
    }
}
