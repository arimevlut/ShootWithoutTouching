using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D Enemy_Rigidbody;
    public Transform target;
    public GameObject Bullet_Object;
    public GameObject Enemy_Explode_Effect;

    public float Enemy_Speed;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Enemy_Move();
    }

    public virtual void Enemy_Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), Enemy_Speed * Time.deltaTime);
    }

    private void Enemy_Destroy()
    {
        GameObject e = Instantiate(Enemy_Explode_Effect, transform.position, Quaternion.identity);
        Destroy(e, 0.75f);
        GameObject d = Instantiate(Bullet_Object, transform.position, Quaternion.identity);
        Destroy(d, 2f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Normal_Bullet")
        {
            GameManager.instance.point += 1;
            Enemy_Destroy();
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(col.gameObject);
        }
    }
}
