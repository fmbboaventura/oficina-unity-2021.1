using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeManager : MonoBehaviour
{
    public int maxLife = 3;
    protected int currentLife = 0;
    public GameObject explosao;

    private AudioSource hitSound;

    private ParticleSystem ps;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        AddLife(maxLife);
        hitSound = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void TomarDano(int dano)
    {
        AddLife(-dano);
        
        sr.color = new Color(1, 0, 0, 1);

        if (ps != null)
        {
            ps.Play();
        }

        if (currentLife <= 0)
        {
            Morrer();
        } else {
            if (hitSound != null) 
                hitSound.Play();
            // Reseta a cor depois de 0.1s
            Invoke("ResetCor", .1f);
        }
    }

    void ResetCor()
    {
        sr.color = new Color(1, 1, 1, 1);
    }

    public virtual void AddLife(int life) {
        currentLife = Mathf.Clamp(currentLife + life, 0, maxLife);
    }

    protected abstract void Morrer();
}
