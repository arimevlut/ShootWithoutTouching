using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Bullet : MonoBehaviour
{
    PlayerController Player_Controller_Script;
    Rigidbody2D Normal_Bullet_Rigidbody;

    private Vector2 target;

    public float Bullet_Speed;

    void Start()
    {
        Normal_Bullet_Rigidbody = GetComponent<Rigidbody2D>();
        Player_Controller_Script = FindObjectOfType<PlayerController>();

        target = new Vector2(Player_Controller_Script.ShootPoint.x, Player_Controller_Script.ShootPoint.y);
    }

    void Update()
    {
        Bullet_Move();
    }

    private void Bullet_Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Bullet_Speed * Time.deltaTime);

        if (target.x == transform.position.x && target.y == transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
