using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    /*
    * aqui é um script pra clicar e arrastar algum objeto
    * deixei separado do minigame pois pode ser usado em outro
    * é so colocar no objeto que vai ter esse comportamento
    */

    Vector3 offset;
    float zCoord;
    public bool mouseDown = false, beingDrag = false;

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        mouseDown = true;
        beingDrag = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
        mouseDown = false;
        beingDrag = true;
    }

    void OnMouseUp()
    {
        beingDrag = false;
    }
}
