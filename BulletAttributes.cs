using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*该脚本无需挂载，通过其他脚本动态添加到炮弹上*/
public class BulletAttributes : MonoBehaviour
{
    public float damage;//炮弹伤害

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
        
        Destroy(transform.gameObject);//移除子弹
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
