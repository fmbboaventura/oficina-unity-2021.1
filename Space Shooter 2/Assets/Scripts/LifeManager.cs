using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private int hpAtual = 0;

    public int maxHp = 3;

    
    // Start is called before the first frame update
    void Start()
    {
        AddHp(maxHp);
    }
    
    public void AddHp(int hp)
    {
        hpAtual = (hpAtual + hp) > maxHp ? maxHp : (hpAtual + hp);
    }

    public void TomarDano(int dano)
    {
        AddHp(-dano);

        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);

        Invoke("ResetCor", .1f);

        if (hpAtual <= 0 )
        {
            Morrer();
        } else {
            GetComponent<AudioSource>().Play();
        }
    }

    void ResetCor()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    public void Morrer()
    {
        Debug.Log(gameObject.name + " morreu");
        if (gameObject.layer == LayerMask.NameToLayer("Inimigo"))
        {
            GameController.instance.AtualizarScore(100);
        } 
        else if (gameObject.layer == LayerMask.NameToLayer("Player")) {
            GameController.instance.MostrarGameOver();
        }
        Destroy(gameObject);
    }
}
