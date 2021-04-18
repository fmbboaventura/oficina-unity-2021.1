using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBasico : MonoBehaviour
{
    public float velocidade = 6;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade, 0);
    }
}
