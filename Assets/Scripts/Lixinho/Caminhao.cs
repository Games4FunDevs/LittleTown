using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminhao : MonoBehaviour
{
    float dragSpeed = 0.05f;
    Vector3 lastMousePos;
   
    void OnMouseDown() {
        lastMousePos = Input.mousePosition;
    }
   
    void OnMouseDrag() {
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.position;
        pos.x += delta.x * dragSpeed;
        transform.position = pos;
        lastMousePos = Input.mousePosition;
    }
}
