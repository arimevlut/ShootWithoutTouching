using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Bullet_Object : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }        
    }
}
