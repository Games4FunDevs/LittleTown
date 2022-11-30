using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Fade fade;
    public AudioSource button;
    public Button continuarBtn;

    void Awake()
    {
        if (PlayerPrefs.GetString("NovoJogo") == "false") { continuarBtn.interactable = true; }
    }

    public void NewGame() 
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("NovoJogo", "true"); 
        PlayerPrefs.SetString("LixoTutor", "true");
        PlayerPrefs.SetString("LojaTutor", "true");
        Continuar();
    }

    public void Continuar()
    {
        fade.ChangeScene("Hub");
        button.Play();
    }
}
