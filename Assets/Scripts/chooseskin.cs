using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseskin : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        if (PlayerPrefs.GetString("player") == "mina")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            anim = gameObject.transform.GetChild(0).GetComponentInChildren<Animator>();
        }
        else if (PlayerPrefs.GetString("player") == "cara")
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
            anim = gameObject.transform.GetChild(1).GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
