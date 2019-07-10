using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text Level_Text;
    public Text Point_Text;
    public Text Green_Bullet_Text;

    void Start()
    {
        
    }

    void Update()
    {
        Level_Text.text = "LEVEL : " + GameManager.instance.level.ToString();
        Point_Text.text = "POINT : " + GameManager.instance.point.ToString();
        Green_Bullet_Text.text = " X : " + GameManager.instance.green_bullet_count.ToString();
    }

    public void Exit_Button()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
