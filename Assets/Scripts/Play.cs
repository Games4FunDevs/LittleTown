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

    float speed = 6f, rotSpeed = 150f, gravidade = 8f;
    Vector3 inputDir, v_velocity;
    CharacterController cc;
    Fade fadecs;

    void Awake() 
    {
        cc = GetComponent<CharacterController>();
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
    }

    void FixedUpdate()
    {   
        Movement();
        if (cc.isGrounded) { v_velocity.y = 0; }
        else { v_velocity.y -= gravidade * Time.deltaTime; }
    }

    void Movement()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move = cc.transform.forward * input.y;
        cc.transform.Rotate(Vector3.up * input.x * (rotSpeed * Time.deltaTime));
        cc.Move(move * speed * Time.deltaTime);
        cc.Move(v_velocity);
    }

    void OnTriggerStay(Collider col) 
    {   // se colidir com objeto de certa tag
        
        // switch (col.gameObject.tag) 
        // {
        //     case "j1": // minigame da loja
        //         if (col.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
        //             && Input.GetButton("Fire1"))
        //                 fadecs.ChangeScene("loja"); 
        //         break;
        //     case "j4":
        //         if (col.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
        //             && Input.GetButton("Fire1"))
        //                 fadecs.ChangeScene("lixo");
        //         break;
        //     case "j2":
        //         if (col.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true 
        //             && Input.GetButton("Fire1"))
        //                 fadecs.ChangeScene("semaforos");
        //         break;
        // }
    }
}
