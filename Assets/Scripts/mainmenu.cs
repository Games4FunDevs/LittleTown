using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Fade fade;
    public AudioSource button;

    void Awake()
    {
        if (PlayerPrefs.GetString("NovoJogo") != "false")
        {
            PlayerPrefs.SetString("NovoJogo", "true");
        }
    }

    void Update() 
    {
        if (Input.anyKey)
        {
            fade.ChangeScene("Hub");
            button.Play();
        }
    }
}
