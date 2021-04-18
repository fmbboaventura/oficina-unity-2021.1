using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManterNaTela : MonoBehaviour
{
    protected Vector2 limitesDaTela;
    protected float altura;
    protected float largura;
    protected Rigidbody2D rb;

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        limitesDaTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        largura = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        altura = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -1 * limitesDaTela.x + largura, limitesDaTela.x - largura),
            Mathf.Clamp(transform.position.y, -1 * limitesDaTela.y + altura, limitesDaTela.y - altura)
        );
    }
}
