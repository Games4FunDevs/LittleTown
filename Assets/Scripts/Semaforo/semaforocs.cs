using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class semaforocs : MonoBehaviour
{
    float speed = 3f, rotSpeed = 5f, gravidade = 9f;
    public Transform[] pontos;
    Vector3 targetPos, v_velocity;
    public int currentN = 0;
    Fade fadecs;
    CharacterController cc;
    semaforo semaforo;

    void Start() 
    {
        cc = GetComponent<CharacterController>();
        targetPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z);
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
    }

    void Update() 
    {
        NextPosition();
    }

    void FixedUpdate()
    {   
        Movement();
        Rotation();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("ponto"))
        {
            ChangePoint();
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (col.gameObject.name.Contains("Semáforo"))
        {
            semaforo = col.gameObject.GetComponent<semaforo>();
        }
    }

    void NextPosition()
    {
        //Debug.Log(this.transform.position + " | " + targetPos);
        if (Vector3.Distance(transform.position, targetPos) < 1.5f && Input.GetButtonDown("Fire1") 
            && semaforo.status == false)
        {
            ChangePoint();
        }
        // se chegou no último
        else if (Vector3.Distance(transform.position, targetPos) < 1.5f && currentN == pontos.Length - 1)
        {
            fadecs.ChangeScene("Hub");
        }
    }

    void ChangePoint()
    {
        currentN++;
        targetPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z);
    }

    void Movement()
    {
        Vector3 moveVector = targetPos - transform.position;
        targetPos.y = 0;
        cc.Move(moveVector * Time.deltaTime * speed);
        // gravidade
        if (cc.isGrounded) { v_velocity.y = 0; }
        else { v_velocity.y -= gravidade * Time.deltaTime; }
    }

    void Rotation()
    {
        Vector3 lookPos;
        if (currentN != pontos.Length-1)
        {
            lookPos = new Vector3(pontos[currentN+1].position.x, transform.position.y, pontos[currentN+1].position.z) - transform.position;
        }
        else
        {
            lookPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z) - transform.position;
        }
            
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);
    }
}
