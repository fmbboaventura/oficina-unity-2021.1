using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBoss : ManterNaTela
{
    public float velocidade = 5f;

    private bool pronto = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rb.velocity = new Vector2(-velocidade, 0);
    }

    new void Update()
    {
        if (pronto) {
            if (rb.position.y  > (limitesDaTela.y - altura) || rb.position.y < (-limitesDaTela.y + altura)) {
                rb.velocity = new Vector2(0, -rb.velocity.y);
            }
            base.Update();
        } else  {
            if (!pronto && rb.position.x  < (limitesDaTela.x - largura - 1)) {
                pronto = true;
                rb.velocity = new Vector2(0, -velocidade);
                gameObject.layer = LayerMask.NameToLayer("Enemy");
            }

        }
    }
}
