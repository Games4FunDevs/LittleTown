// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Lixeira : MonoBehaviour
// {
//     public Transform[] ponto; // pontos pro lixo passar

//     Lixo lixo;
//     Draggable dragcs;
//     GameObject lixeiraChild;

//     bool x = true, canDo = false;
    
//     public Color objectColor, fadeColor = Color.red, targetColor = Color.white;
//     public float fadeTime = 1f, fadeStart = 0, timePassed;

//     void Start()
//     {
//         lixeiraChild = gameObject.transform.Find("Lixeira").gameObject;
//         objectColor = lixeiraChild.GetComponent<MeshRenderer>().material.color;

//         for (int i = 0; i < this.gameObject.transform.childCount - 2; i++)
//         {
//             ponto[i] = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Transform>();
//         }
//     }

//     void Update()
//     {
//         if (lixo != null ) // se ainda nao passou
//         {
//             if (lixo.status == 0)
//             {
//                 if (lixo.tipo == this.gameObject.name && dragcs.m == 1) // se é do mesmo tipo da lixeira
//                 {
//                     canDo = true;
//                 }
//                 else if (lixo.tipo != this.gameObject.name)
//                 {
//                     canDo = false;
//                 }
//             }

//             if (canDo)
//             {
                
//                 lixo.gameObject.GetComponent<Rigidbody>().useGravity = false;
//                 lixeiraChild.GetComponent<Animator>().SetInteger("s", 1); // chama a animacao
//                 lixo.transform.position = Vector3.MoveTowards(lixo.transform.position, ponto[0].position, 3 * Time.deltaTime); // move
//                 if (x == true) // se pode chamar a particula
//                 {
//                     gameObject.transform.Find("ringParticle").GetComponent<ParticleSystem>().Play();
//                     x = false;
//                 }
//             }
//             else
//             {
//                 lixeiraChild.GetComponent<Animator>().SetInteger("s", 2); // animacao de erro
//                 for (int i = 0; timePassed < fadeTime; i++) // fade red
//                 {
//                     timePassed += Time.deltaTime;
//                     lixeiraChild.GetComponent<MeshRenderer>().material.color = Color.Lerp(objectColor, fadeColor, timePassed / fadeTime);
//                 }
//                 if (lixeiraChild.GetComponent<MeshRenderer>().material.color == fadeColor)
//                 {
//                     for (int i = 0; timePassed > 0; i++) // 
//                     {
//                         timePassed -= Time.deltaTime;
//                         lixeiraChild.GetComponent<MeshRenderer>().material.color 
//                             = Color.Lerp(lixeiraChild.GetComponent<MeshRenderer>().material.color, objectColor, timePassed / fadeTime);
//                     }
//                     lixeiraChild.GetComponent<Animator>().SetInteger("s", 0); //
//                 }
//             }

//             if (lixo.transform.position == ponto[0].position) // voa pro primeiro ponto
//             { 
//                 lixo.status = 1; x = true; // vai pro proximo ponto
//             }

//             if (lixo.status == 1) // passa pro segundo ponto dentro da lixeira
//             {
//                 // this.gameObject.GetComponent<BoxCollider>().enabled = false;
//                 lixo.transform.position = Vector3.MoveTowards(lixo.transform.position, ponto[1].position, 3 * Time.deltaTime); // move
//             }

//             if (lixo.transform.position == ponto[1].position) // se chegou na lixeira
//             { 
//                 lixeiraChild.GetComponent<Animator>().SetInteger("s", 0);
//                 Destroy(lixo.gameObject); // destroi desintegra oblitera ele :)
//             } 
//         }
//     }

//     void OnTriggerEnter(Collider col)
//     {
//         if (col.name.Contains("Lixo"))
//         {
//             lixo = col.gameObject.GetComponent<Lixo>();
//             dragcs = col.gameObject.GetComponent<Draggable>();
//             this.gameObject.GetComponent<Rigidbody>().useGravity = true;
//         }
//     }

//     void OnTriggerStay(Collider col)
//     {
//         if (col.name.Contains("Lixeira"))
//         {
//         }
//     }

//     void OnTriggerExit(Collider col)
//     {
//         if (col.name.Contains("Lixo"))
//         {
//             lixo = null;
//         }
//     }
// }














// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Lixo : MonoBehaviour
// {
//     public Transform[] ponto; // lugares que o lixo deve ir
//     public int passou = 0; // status do lixo
//     public string tipo; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
//     Collider colisao; // objeto que ta colidindo
//     Draggable dragcs;
//     bool x = true;
//     public string fadeS = "zero";

//     public Color objectColor, fadeColor = Color.red, targetColor = Color.white;
//     public float fadeTime = 1f, fadeStart = 0, timePassed;
 
//     void Start() => this.dragcs = GetComponent<Draggable>();
    
//     void Update() 
//     {
//         if (this.ponto[0] != null) // se pegou os pontos 
//         {
//             if (this.passou == 0) // se ainda nao passou
//             {
//                 if (this.tipo == this.colisao.name) // se é do mesmo tipo da lixeira
//                 {
//                     this.gameObject.GetComponent<Rigidbody>().useGravity = false;
//                     this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // move
//                     if (this.x == true) // se pode chamar a particula
//                     {
//                         this.colisao.gameObject.transform.Find("ringParticle").GetComponent<ParticleSystem>().Play();
//                         this.x = false;
//                     }
//                 }
//                 else //&& y == -1 se não é do tipo da lixeira e estado 0 de fade
//                 {
//                     //this.y = 0; // fade red
//                     this.colisao.gameObject.transform.Find("Lixeira").GetComponent<Animator>().SetInteger("s", 2); // animacao de erro
//                     for (int i = 0; this.timePassed < this.fadeTime; i++) // fade red
//                     {
//                         this.timePassed += Time.deltaTime;
//                         this.colisao.gameObject.transform.Find("Lixeira").GetComponent<MeshRenderer>().material.color 
//                             = Color.Lerp(objectColor, fadeColor, this.timePassed / this.fadeTime);
//                     }
//                 }
//             } 

//             if (fadeS == "fullRed")
//             {
//                 for (int i = 0; this.timePassed > 0; i++) // fade de volta
//                 {
//                     this.timePassed -= Time.deltaTime;
//                     this.colisao.gameObject.transform.Find("Lixeira").GetComponent<MeshRenderer>().material.color 
//                         = Color.Lerp(objectColor, objectColor, this.timePassed / this.fadeTime);
//                 }
//                 this.colisao.gameObject.transform.Find("Lixeira").GetComponent<Animator>().SetInteger("s", 0); // animacao idle
//             }

//             if (this.transform.position == this.ponto[0].position) // voa pro primeiro ponto
//             { 
//                 this.passou = 1; x = true; // vai pro proximo ponto
//             }

//             if (this.passou == 1) // passa pro segundo ponto dentro da lixeira
//             {
//                 // this.gameObject.GetComponent<BoxCollider>().enabled = false;
//                 this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 3 * Time.deltaTime); // move
//             }

//             if (this.transform.position == this.ponto[1].position) // se chegou na lixeira
//             { 
//                 this.colisao.gameObject.transform.Find("Lixeira").GetComponent<Animator>().SetInteger("s", 0);
//                 Destroy(this.gameObject); // destroi desintegra oblitera ele :)
//             } 
//         }
//     }

//     // pra saber quando soltou o mouse, só essa gambiarra funfou :|
//     public int mouseStatus = 0;
//     void OnMouseDrag() { this.mouseStatus = 1; }
//     void OnMouseUp() { this.mouseStatus = 2; }
//     //

//     void OnTriggerEnter(Collider col)
//     {
//         if (col.name.Contains("Lixeira"))
//         {
//             //colisao = col;
//             this.gameObject.GetComponent<Rigidbody>().useGravity = true;
//             this.objectColor = col.gameObject.transform.Find("Lixeira").GetComponent<MeshRenderer>().material.color;
//         }
//     }

//     void OnTriggerStay(Collider col)
//     {
//         if (col.name.Contains("Lixeira"))
//         {
//             this.colisao = col;
//             if (this.tipo == col.name)
//             {
//                 col.gameObject.transform.Find("Lixeira").GetComponent<Animator>().SetInteger("s", 1);; // chama a animacao
//             }

//             if (this.mouseStatus == 1) 
//             {
//                 for (int j = 0; j < col.gameObject.transform.childCount - 2; j++) // pega os pontos
//                 { 
//                     this.ponto[j] = col.transform.GetChild(j).transform; 
//                 } 
//             }
//         }
//     }
//     void OnTriggerExit(Collider col)
//     {   // para a animacao
//         if (col.name.Contains("Lixeira"))
//         {
//             col.gameObject.transform.Find("Lixeira").GetComponent<Animator>().SetInteger("s", 0);
//         }
//     }
// }

