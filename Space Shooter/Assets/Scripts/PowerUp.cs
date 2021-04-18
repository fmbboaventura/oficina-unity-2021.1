using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;

    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidade, 0);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        outro.gameObject.GetComponent<PlayerController>().LevelUp();
        outro.gameObject.GetComponent<LifeManager>().AddLife(1);
        GameController.SharedInstance.AddScore(100);
        AudioSource.PlayClipAtPoint(pickupSound, Vector3.zero);
        Destroy(gameObject);
    }
}
