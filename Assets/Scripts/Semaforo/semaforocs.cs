using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class semaforocs : MonoBehaviour
{
    float speed = 6f, rotSpeed = 150f;
    public Transform[] pontos;
    Vector3 targetPos;
    public int currentN = 0;
    Fade fadecs;
    Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < GameObject.Find("pontos").gameObject.transform.childCount; i++)
        {
            pontos[i] = GameObject.Find("pontos").gameObject.transform.GetChild(i).GetComponent<Transform>();
        }
        targetPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z);
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
    }

    void Update() 
    {
        NextPosition();
    }

    void FixedUpdate()
    {   
        if (this.transform.position.x != targetPos.x && this.transform.position.z != targetPos.z )
        {
            Movement();
        }
        // Rotation();
    }

    void NextPosition()
    {
        Debug.Log(this.transform.position + " | " + targetPos);
        if (this.transform.position.x == targetPos.x && this.transform.position.z == targetPos.z 
            && Input.GetKey(KeyCode.A))
        {
            currentN++;
            targetPos = new Vector3(pontos[currentN].position.x, transform.position.y, pontos[currentN].position.z);;
        }
        // se chegou no último
        else if (this.transform.position.x == targetPos.x && this.transform.position.z == targetPos.z
            && currentN == pontos.Length-1)
        {
            fadecs.ChangeScene("Hub");
        }
    }

    void Movement()
    {
        // Vector3 actualTargetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
        // Vector3 newPos = Vector3.MoveTowards(transform.position, actualTargetPos, speed * Time.deltaTime);
        // transform.position = newPos;

        // var lookPos = targetPos - transform.position;
        // lookPos.y = 0;

        // Vector3 targetDirection = (lookPos - transform.position).normalized;
        // rb.MovePosition(transform.position + targetDirection * Time.deltaTime * speed);

        // Vector3 x = new Vector3(targetPos.x, transform.position.y, targetPos.z).normalized;
        // if (Vector3.Distance(transform.position, x) > 0)
        // {
        //     rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        // }
    }

    void Rotation()
    {
        var lookPos = targetPos - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
    }
}
