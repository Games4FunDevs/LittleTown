using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoMinigame : MonoBehaviour
{
    public int qtdLixo = 5, spawnLixo; // quantos lixos vao spawnar
    int tipo = 0; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    public Transform spawnPoint; // ponto de spawn
    public GameObject[] prefab; // o objeto do lixo

    void Start() => spawnLixo = qtdLixo;

    void Update()
    {
        if (spawnLixo != qtdLixo)
        {
            tipo = Random.Range(0, 4); // escolhe o tipo
            Instantiate(prefab[tipo], spawnPoint.position, Quaternion.identity); // spawna
            spawnLixo = qtdLixo;
        }
    }
}
