using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    GameObject player;

    void Awake() => player = GameObject.Find("Player");

    void Update() 
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        if (Vector3.Distance(this.transform.position, this.player.transform.position) < 7f)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
