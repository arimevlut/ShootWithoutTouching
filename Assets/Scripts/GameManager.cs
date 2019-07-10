using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int level;
    public int point;
    public int green_bullet_count;
    //public int blue_bullet_count;
    //public int red_bullet_count;

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        point = 0;
        level = 1;
        green_bullet_count = 5;
        //blue_bullet_count = 0;
        //red_bullet_count = 0;
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
