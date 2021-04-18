using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public float velocidade = 8f;

    public float velocidadeAngular = 50;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidade, 0);
        rb.angularVelocity = (Random.value > 0.5f) ? velocidadeAngular : - velocidadeAngular;
    }
}
