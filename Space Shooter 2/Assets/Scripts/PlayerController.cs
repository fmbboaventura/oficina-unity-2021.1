using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float velocidade = 8;

    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direcao.normalized * velocidade;

        if (Input.GetKeyDown("space")){
            GameObject laser = Instantiate(laserPrefab);
            GameObject arma = transform.Find("Arma").gameObject;
            laser.transform.position = arma.transform.position;
            arma.GetComponent<AudioSource>().Play();
        }
    }
}
