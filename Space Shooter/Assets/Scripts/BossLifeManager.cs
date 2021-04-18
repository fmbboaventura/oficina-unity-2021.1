using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeManager : LifeManager
{

    private bool morreu = false;

    private int maxExpl = 10;

    private int curExpl = 0;

    private float proximaExplosao = 0;

    private float raio;
    public override void AddLife(int life)
    {
        base.AddLife(life);
        GameController.SharedInstance.AtualizarLifeBoss(currentLife);
    }
    
    protected override void Morrer()
    {
        morreu = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
        raio = GetComponent<CircleCollider2D>().radius;
        GameController.SharedInstance.AddScore(10);
    }
    
    void Update()
    {
        if (morreu && Time.time > proximaExplosao)
        {
            GameObject e = Instantiate(explosao) as GameObject;

            if (curExpl < maxExpl)
            {
                e.transform.position = (Random.insideUnitSphere * raio * 2) + transform.position;
                e.transform.parent = gameObject.transform;
            } else 
            {
                e.transform.position = transform.position;
                e.transform.localScale = transform.localScale;
            }


            proximaExplosao = Time.time + Random.Range(0.2f,0.5f);
            curExpl++;

            if (curExpl > maxExpl)
                Destroy(gameObject);
            {
            }
        }
    }
}
