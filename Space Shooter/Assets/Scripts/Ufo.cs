using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : Meteoro
{
    public GameObject laser;
    public float tempoEntreDisparos = 0.5f;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tempoEntreDisparos) {
            timer = 0;
            foreach (Transform child in transform)
            {
                Instantiate(laser, child.position, child.rotation);
                child.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
