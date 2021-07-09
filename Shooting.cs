using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*该脚本挂载于炮管上*/
public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;//炮弹预制体
    GameObject bullet;//炮弹
    public float bulletVelocity;//炮弹初速
    public bool gravityActive;//炮弹是否使用重力
    public float reloadTime;//装填时间
    float timeSinceLastShoot;//上次发炮时间

    //射击
    private void Shoot()
    {
        bullet = GameObject.Instantiate(bulletPrefab, transform.position+3f*transform.forward, transform.rotation);//创建炮弹模型
        bullet.AddComponent<BulletAttributes>();//给炮弹添加脚本
        bullet.GetComponent<BulletAttributes>().SetDamage(transform.parent.parent.GetComponent<TankAttributes>().GetDamage());//设置炮弹伤害
        bullet.AddComponent<BoxCollider>();//添加碰撞体
        bullet.AddComponent<Rigidbody>();//添加刚体
        bullet.GetComponent<Rigidbody>().useGravity = gravityActive;//调整重力
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;//设置初速
        transform.parent.parent.GetComponent<TankAttributes>().bulletCount--;//炮弹数-1
        timeSinceLastShoot = Time.time;//重置上次发炮时间
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
