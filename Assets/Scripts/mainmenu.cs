using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Fade fade;

    void Update() 
    {
        if (Input.anyKey)
        {
            fade.ChangeScene("Hub");
        }
    }
}
