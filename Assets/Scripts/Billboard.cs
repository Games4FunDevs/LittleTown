using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    GameObject player;
    public Fade fadecs;
    bool colideLixo = false;

    void Awake()
    {
        player = GameObject.Find("Player");
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
    }

    void Update() 
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        if (Vector3.Distance(this.transform.position, this.player.transform.position) < 6f)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (colideLixo == false)
            {
                if (Input.GetButton("Fire1"))
                {
                    switch (this.gameObject.transform.parent.tag) 
                    {
                        case "j1": // minigame da loja
                            if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
                                && Input.GetButton("Fire1"))
                                    fadecs.ChangeScene("loja"); 
                            break;
                        case "j4":
                            if (player.GetComponent<Play>().lixoColetado >= 4 && this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
                                && Input.GetButton("Fire1"))
                                    fadecs.ChangeScene("lixo");
                            break;
                            break;
                        case "j2":
                            if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
                                && Input.GetButton("Fire1"))
                                    fadecs.ChangeScene("semaforos");
                            break;
                    }
                }
            }
            
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "lixo")
        {
            colideLixo = false;
        }
        else
        {
            colideLixo = true;
        }
    }
}
