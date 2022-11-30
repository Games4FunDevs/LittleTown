using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseskin : MonoBehaviour
{
    private Animator anim;
    public mainmenu mainmenu_;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Hub" || SceneManager.GetActiveScene().name == "semaforos")
        {
            if (PlayerPrefs.GetString("player") == "mina")
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);
                anim = gameObject.transform.GetChild(0).GetComponentInChildren<Animator>();
            }
            if (PlayerPrefs.GetString("player") == "cara")
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(true);
                anim = gameObject.transform.GetChild(1).GetComponentInChildren<Animator>();
            }
        }
    }

    public void ChoosenSkin()
    {
        if (this.gameObject.name.Contains("mina"))
        {
            PlayerPrefs.SetString("player", "mina");
        }
        if (this.gameObject.name.Contains("cara"))
        {
            PlayerPrefs.SetString("player", "cara");
        }
        mainmenu_.Continuar();
    }
}
