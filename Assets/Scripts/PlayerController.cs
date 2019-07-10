using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Player_Rigidbody;

    public GameObject Bullet_Prefab;
    public GameObject Die_Effect;
    public Transform Bullet_Exit_Point;
    public Vector3 ShootPoint;

    public float Player_Speed;
    public float Player_Bullet_Count;
    
    private void Start()
    {
        Player_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.green_bullet_count > 0)
        {
            ShootPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Player_Shoot();
            GameManager.instance.green_bullet_count -= 1;
            if (GameManager.instance.green_bullet_count <= 0)
            {
                GameManager.instance.green_bullet_count = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Player_Move(x, y);
    }

    private void Player_Move(float x,float y)
    {
        Player_Rigidbody.velocity = new Vector2(x, y) * Player_Speed;
    }

    private void Player_Shoot()
    {
        Instantiate(Bullet_Prefab, Bullet_Exit_Point.position, Quaternion.identity);
    }

    private void Player_Die()
    {
        Destroy(this.gameObject);
        GameObject e = Instantiate(Die_Effect, transform.position, Quaternion.identity);
        Destroy(e, 0.75f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Normal_Bullet_Object")
        {
            Destroy(col.gameObject);
            GameManager.instance.green_bullet_count += 5;
        }

        if (col.gameObject.tag == "Orange_Enenmy")
        {
            Player_Die();
        }

        if (col.gameObject.tag == "Blue_Enemy")
        {
            Player_Die();
        }
    }

}
