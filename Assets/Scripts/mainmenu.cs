using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Fade fade;
    public AudioSource button;
<<<<<<< Updated upstream
=======
    public Button continuarBtn;
    public GameObject skinPanel, others;
>>>>>>> Stashed changes

    void Update() 
    {
<<<<<<< Updated upstream
        if (Input.anyKey)
        {
            fade.ChangeScene("Hub");
            button.Play();
        }
=======
        if (PlayerPrefs.GetString("NovoJogo") == "false") { continuarBtn.interactable = true; }
    }

    public void NewGame() 
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("NovoJogo", "true"); 
        PlayerPrefs.SetString("LixoTutor", "true");
        PlayerPrefs.SetString("LojaTutor", "true");
        skinPanel.SetActive(true);
        others.SetActive(false);
    }

    public void Continuar()
    {
        fade.ChangeScene("Hub");
        button.Play();
>>>>>>> Stashed changes
    }

    public void ChooseSkin()
    {
        if (this.gameObject.name == "mina")
        {
            PlayerPrefs.SetString("player", "mina");
        }
        else if (this.gameObject.name == "cara")
        {
            PlayerPrefs.SetString("player", "cara");
        }
        Continuar();
    }
}
