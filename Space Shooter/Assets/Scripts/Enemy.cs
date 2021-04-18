using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject laser;
    private float proximoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        proximoDisparo += Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > proximoDisparo)
        {
            GameObject l = Instantiate(laser) as GameObject;
            GameObject arma = transform.Find("Arma").gameObject;
            l.transform.position = arma.transform.position;
            l.transform.Rotate(new Vector3(0, 0, 90));
            arma.GetComponent<AudioSource>().Play();
            proximoDisparo = Time.time + Random.Range(0.5f,1.5f);
        }
    }
}
