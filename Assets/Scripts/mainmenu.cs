using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Fade fade;
    public AudioSource button;
    public GameObject skinObj, others, continuarBtn, newGameBtn;

    void Awake()
    {
        if (PlayerPrefs.GetString("NovoJogo") == "false") 
        { 
            continuarBtn.SetActive(true); 
            newGameBtn.SetActive(false);
        }
        else
        {
            continuarBtn.SetActive(false); 
            newGameBtn.SetActive(true);
        }
    }

    public void NewGame() 
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("NovoJogo", "true"); 
        PlayerPrefs.SetString("LixoTutor", "true");
        PlayerPrefs.SetString("LojaTutor", "true");
        PlayerPrefs.SetString("Skin", "true");
        skinObj.SetActive(true);
        others.SetActive(false);
    }

    public void Continuar()
    {
        fade.ChangeScene("Hub");
        button.Play();
    }
}
