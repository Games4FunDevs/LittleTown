using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class playermov : MonoBehaviour
{
    private float speed = 1f, rotSpeed = 5f, gravidade = 9f, timer = 30f;
    public Transform[] pontos;
    private Vector3 targetPos, v_velocity;
    public int currentN = 0;
    private Fade fadecs;
    private CharacterController cc;
    public semaforo sc;
    private Controles controles;

    void Awake() 
    {
        cc = GetComponent<CharacterController>();
        targetPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z);
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
        controles = new Controles();
        controles.Enable();

        
    }

    void Update() 
    {
        NextPosition();
        timer -= Time.deltaTime * Time.timeScale;
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
            sc = col.gameObject.GetComponent<semaforo>();
        }
    }

    void NextPosition()
    {
        if (Vector3.Distance(transform.position, targetPos) < 1.5f && sc.status == true
            && controles.ActionMap.Interagir.ReadValue<float>() > 0)
        {
            ChangePoint();
        }
        // se chegou no último
        else if (Vector3.Distance(transform.position, targetPos) < 1.5f && currentN == pontos.Length - 1 || timer <= 0)
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
        cc.Move(moveVector * Time.deltaTime * speed * Time.timeScale);
        // gravidade
        if (cc.isGrounded) { v_velocity.y = 0; }
        else { v_velocity.y -= gravidade * Time.deltaTime * Time.timeScale; }
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
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed * Time.timeScale);
    }
}
