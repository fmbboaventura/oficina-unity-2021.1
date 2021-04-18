using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManterNaTela : MonoBehaviour
{
    Vector2 limitesDaTela;

    float largura;

    float altura;

    void Start()
    {
        limitesDaTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        largura = GetComponent<SpriteRenderer>().bounds.extents.x;
        altura = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -limitesDaTela.x + largura, limitesDaTela.x - largura),
            Mathf.Clamp(transform.position.y, -limitesDaTela.y + altura, limitesDaTela.y - altura)
        );
    }
}
