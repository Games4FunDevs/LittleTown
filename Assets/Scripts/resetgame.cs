using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetgame : MonoBehaviour
{
    public void resetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
