﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Start_Button()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
