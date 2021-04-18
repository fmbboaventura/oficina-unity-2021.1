using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoSimples : MonoBehaviour
{
    public float velocidade = 8f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidade, 0);
    }
}
