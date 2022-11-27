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
        
        if (PlayerPrefs.GetString("LixoTutor") != "false")
        {
            PlayerPrefs.SetString("LixoTutor", "true");
        }
        
        if (PlayerPrefs.GetString("LojaTutor") != "false")
        {
            PlayerPrefs.SetString("LojaTutor", "true");
        }
    }

    public void NewGame() 
    {
        PlayerPrefs.DeleteAll();
        Continuar();
    }

    public void Continuar()
    {
        fade.ChangeScene("Hub");
        button.Play();
    }
}
