using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    /*
    * esse scrpit fica no objeto do player, no hub
    * se movimenta pelo cenário e chama outra cena ao interagir com objetos de certa tag
    */

    [SerializeField] int speed = 5;
    Vector3 point;
    bool stop;

    void Awake()
    {
        // seta a posicao incial do player
        point.x = this.transform.position.x;
        point.z = this.transform.position.z;
        point.y = 1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {   // se clicou num lugar
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) { // pega esse ponto na cena
                point.x = hit.point.x;
                point.z = hit.point.z;
            }
        }
        
        // if (stop == false)
        // {
            transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime); // move o objeto ate o ponto
        // }
        // else
        // {
        //     StopPlayer();
        // }
    }

    void OnTriggerEnter(Collider col)
    {   // se colidir com objeto de certa tag
        switch (col.gameObject.tag) 
        {
            case "j1": // minigame da loja
                SceneManager.LoadScene("jogo1");
                break;
            case "j2":
                print("minigame 2");
                break;
            case "j3":
                print("minigame 3");
                break;
        }
    }

    // void OnColliderEnter(Collision col)
    // {
    //     if (col.gameObject.layer != 6) // vai impedir de querer entrar nos objetos
    //     {
    //         stop = true;
    //     }
    //     else
    //     {
    //         stop = false;
    //     }
    // }

    // void StopPlayer()
    // {
    //     speed = 0;
    //     point = transform.position;
    // }
}
