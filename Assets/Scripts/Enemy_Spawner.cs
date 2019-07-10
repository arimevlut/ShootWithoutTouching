using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    PlayerController Player_Controller_Script;
    EnemyController Enemy_Controller_Script;

    public GameObject[] Enemy;
    public Transform Player_Position;

    float Current_Time;
    float Current_Time2;
    float Create_Time;
    float Create_Time2;
    float Enemy_X_Axis;
    float Enemy_Y_Axis;
    int i;

    void Start()
    {
        i = 0;
        Create_Time = 1f;
        Create_Time2 = 10f;

        Player_Controller_Script = FindObjectOfType<PlayerController>();
        Enemy_Controller_Script = FindObjectOfType<EnemyController>();
    }

    void Update()
    {
        Player_Position.position = Player_Controller_Script.transform.position;

        Current_Time += Time.deltaTime;
        if (Current_Time >= Create_Time)
        {
            Current_Time = 0;
            Create_Time = 4f;
            Spawner();
        }

        Current_Time2 += Time.deltaTime;
        if (Current_Time2 >= Create_Time2)
        {
            Current_Time2 = 0;
            Increase_Level();
        }

    }

    private void Spawner()
    {      
        Enemy_X_Axis = Random.Range(-15f, 15f);
        Enemy_Y_Axis = Random.Range(-12f, 12f);

        if(Enemy_X_Axis == Player_Position.position.x && Enemy_Y_Axis == Player_Position.position.y)
        {
            Enemy_X_Axis = Random.Range(-15f, 15f);
            Enemy_Y_Axis = Random.Range(-12f, 12f);
        }

        Instantiate(Enemy[i], new Vector2(Enemy_X_Axis, Enemy_Y_Axis), Quaternion.identity);
    }

    private void Increase_Level()
    {
        GameManager.instance.level = 2;
        i = 1;
    }
}
