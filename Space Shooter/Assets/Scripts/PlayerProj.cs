using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProj : MonoBehaviour
{
    public float velocidade = 20f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocidade, 0);
    }
    void OnTriggerEnter2D(Collider2D outro)
    {
        outro.gameObject.GetComponent<LifeManager>().TomarDano(1);
        Destroy(gameObject);
    }
}
