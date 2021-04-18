using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAleatorio : ManterNaTela
{
    private float tChange = 0;

    private Vector2 velocidadeRnd;

    public float velocidade = 8f;

    private bool pronto = false;

    private Enemy enemyScript;

    new void Start()
    {
        enemyScript = GetComponent<Enemy>();
        enemyScript.enabled = false;
        base.Start();
        rb.velocity = new Vector2(-velocidade, 0);
    }
    
    // Update is called once per frame
    new void Update()
    {
        if (pronto) {
            if (Time.time > tChange)
            {
                velocidadeRnd = (new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized) * velocidade;
                tChange = Time.time + Random.Range(0.5f,1.5f);
            }

            if (rb.position.x  > (limitesDaTela.x - largura) || rb.position.x < (-limitesDaTela.x + largura)) {
                velocidadeRnd.x = -velocidadeRnd.x;
            }

            if (rb.position.y  > (limitesDaTela.y - altura) || rb.position.y < (-limitesDaTela.y + altura)) {
                velocidadeRnd.y = -velocidadeRnd.y;
            }

            rb.velocity = velocidadeRnd;

            base.Update();
        } else  {
            if (!pronto && rb.position.x  < (limitesDaTela.x - largura - 1)) {
                pronto = true;
                enemyScript.enabled = true;
            }

        }
    }
}
