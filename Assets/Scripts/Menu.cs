using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    //
    // código do caderno
    //

    public bool menu = false, open = true, tutor = false, tutor1 = false, tutor2 = false, tutor4;
    public GameObject caderno, op1, op2, t1, t2, txt1, tutorial, tutorial1, tutorial2, tutorial4;
    private EventSystem current;
    private Controles controles;
    public TextMeshProUGUI texto;

    void Awake()
    {
        current = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        controles = new Controles();
        controles.Enable();
        texto.text = "Coletar lixos: " + PlayerPrefs.GetInt("lixos").ToString() + "/5";
        
        if (PlayerPrefs.GetInt("lixos") >= 4)
        {
            txt1.SetActive(true);
        }

        if (PlayerPrefs.GetString("NovoJogo") == "true" && SceneManager.GetActiveScene().name == "Hub")
        {
            tutorial.SetActive(true);
            tutor = true;
        }

        if (PlayerPrefs.GetString("LixoTutor") == "true" && SceneManager.GetActiveScene().name == "lixo")
        {
            tutorial1.SetActive(true);
            tutor1 = true;
        }
        
        if (PlayerPrefs.GetString("SemaforoTutor") == "true" && SceneManager.GetActiveScene().name == "semaforos")
        {
            tutorial4.SetActive(true);
            tutor4 = true;
        }

        if (PlayerPrefs.GetString("LojaTutor") == "true" && SceneManager.GetActiveScene().name == "loja")
        {
            tutorial2.SetActive(true);
            tutor2 = true;
        }
    }

    void Update()
    {
        if (tutor == true && Input.anyKey)
        {
            tutorial.SetActive(false);
            PlayerPrefs.SetString("NovoJogo", "false");
        }

        if (tutor1 == true && Input.anyKey)
        {
            tutorial1.SetActive(false);
            PlayerPrefs.SetString("LixoTutor", "false");
        }

        if (tutor2 == true && Input.anyKey)
        {
            tutorial2.SetActive(false);
            PlayerPrefs.SetString("LojaTutor", "false");
        }

        if (tutor4 == true && Input.anyKey)
        {
            tutorial4.SetActive(false);
            PlayerPrefs.SetString("SemaforoTutor", "false");
        }

        if (controles.ActionMap.Menu.triggered) 
            MenuPanel();

        // Checa se os minigames foram jogados e marca no caderno
        if (PlayerPrefs.GetString("Minigame_Loja") == "Finalizado")
            t1.gameObject.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        if (PlayerPrefs.GetString("Minigame_Lixo") == "Finalizado")
            t1.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        if (PlayerPrefs.GetString("Minigame_Semaforo") == "Finalizado")
            t1.gameObject.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        if (PlayerPrefs.GetInt("lixos") >= 5)
            t1.gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

        // checa se jogou todos os minigames
        if (PlayerPrefs.GetString("Minigame_Semaforo") == "Finalizado" && PlayerPrefs.GetString("Minigame_Loja") == "Finalizado" && PlayerPrefs.GetString("Minigame_Lixo") == "Finalizado" &&
            t1.gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().fontStyle == FontStyles.Strikethrough)
        {
            SceneManager.LoadScene("End");
        }
    }

    public void MenuPanel()
    {
        if (menu != !menu) { menu = !menu; } 
        open = true;
        caderno.SetActive(menu);
        Telas();

        // pausa
        if (SceneManager.GetActiveScene().name == "semaforos" && menu == true) Time.timeScale = 0; 
        else Time.timeScale = 1;
    }

    public void Telas()
    {
        if (open == true || current.currentSelectedGameObject.name == "op1") 
        { 
            t1.SetActive(true);
            if (PlayerPrefs.GetInt("lixos") >= 4)
            {
                txt1.SetActive(true);
            }
            t2.SetActive(false); 
            op1.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
            op2.gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 0);
            open = false;
        } 
        else if (current.currentSelectedGameObject.name == "op2") 
        {
            t1.SetActive(false);
            t2.SetActive(true); 
            op1.gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 0);
            op2.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
    }
}
