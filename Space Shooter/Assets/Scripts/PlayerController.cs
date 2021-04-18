using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 10f;

    private Vector2 direcao;

    private Rigidbody2D rb;

    public GameObject laser;

    private int level;

    void Start()
    {
        level = 1;
        rb = GetComponent<Rigidbody2D>();
    }
    
   // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direcao = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(direcao.x * velocidade, direcao.y * velocidade);

        if(Input.GetKeyDown("space")){
            switch (level)
            {
                case 1: 
                    Atirar(transform.Find("Arma1").gameObject); 
                    break;
                case 2: 
                    Atirar(transform.Find("Arma2").gameObject); 
                    Atirar(transform.Find("Arma3").gameObject); 
                    break;
                case 3: 
                    Atirar(transform.Find("Arma1").gameObject); 
                    Atirar(transform.Find("Arma2").gameObject); 
                    Atirar(transform.Find("Arma3").gameObject);
                    break;
            }
        }
    }

    void Atirar(GameObject arma)
    {
        GameObject l = Instantiate(laser) as GameObject;
        l.transform.position = arma.transform.position;
        arma.GetComponent<AudioSource>().Play();
    }

    public void LevelUp()
    {
        level = (level == 3) ? level : level + 1;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.layer == LayerMask.NameToLayer("Enemy") || outro.gameObject.layer == LayerMask.NameToLayer("EnemyProj"))
        {
            GetComponent<LifeManager>().TomarDano(1);
        }
    }
}
