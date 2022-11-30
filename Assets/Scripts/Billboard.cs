using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Billboard : MonoBehaviour
{
    public GameObject player, t1;
    public Fade fadecs;
    public float distancia = 5f;

    private Controles controles;

    void Awake()
    {
        player = GameObject.Find("Player");
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
        controles = new Controles();
        controles.Enable();
    }

    void Update() 
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        if (Vector3.Distance(this.transform.position, this.player.transform.position) < distancia)
        {
            Interagiu();
        }
    }

    void Interagiu()
    {
        if (controles.ActionMap.Interagir.ReadValue<float>() > 0)
        {
            switch (this.gameObject.transform.parent.tag) 
            {
                case "j1": // minigame da loja
                    if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j1", "true");
                        fadecs.ChangeScene("loja"); 
                    }
                break;
                case "j4":
                    if (PlayerPrefs.GetInt("lixos") >= 5 && this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j4", "true");
                        fadecs.ChangeScene("lixo"); 
                    }
                break;
                case "j2":
                    if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j2", "true");
                        fadecs.ChangeScene("semaforos"); 
                    }
                break;
            }
        }
    }
}