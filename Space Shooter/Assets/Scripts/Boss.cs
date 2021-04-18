using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public List<GameObject> inimigos;

    private float proximoSpawn;

    public float intervaloEntreSpawn = 10;

    void Start()
    {
        proximoSpawn = Time.time + intervaloEntreSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > proximoSpawn)
        {
            GameObject e = Instantiate(inimigos[Random.Range(0, inimigos.Count - 1)]) as GameObject;
            e.transform.position = transform.position;
            proximoSpawn += intervaloEntreSpawn;
        }
    }
}
