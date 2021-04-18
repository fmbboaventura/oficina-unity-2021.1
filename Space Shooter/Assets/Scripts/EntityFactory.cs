using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    public List<GameObject> meteoros;

    private float tempoProximoMeteoro;

    public float tempoEntreMeteoros = 1.5f;

    public List<GameObject> inimigos;

    private float tempoProximoInimigo;

    public float tempoEntreInimigos = 2f;

    public GameObject powerUp;

    public GameObject boss;

    protected Vector2 limitesDaTela;
    protected Rigidbody2D rb;

    private bool instanciouChefe;

    // Start is called before the first frame update
    protected void Start()
    {
        instanciouChefe = false;
        tempoProximoMeteoro = Time.time + 3f;
        tempoProximoInimigo = Time.time + 5f;
        limitesDaTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tempoProximoMeteoro) {
            GameObject e = Instantiate(meteoros[Random.Range(0, meteoros.Count - 1)]) as GameObject;
            e.transform.position = new Vector2(limitesDaTela.x, Random.Range(-limitesDaTela.y, limitesDaTela.y));
            tempoProximoMeteoro += tempoEntreMeteoros;
        }

        if (!instanciouChefe && Time.time > tempoProximoInimigo) {
            int qtdInimigos = Random.Range(1, 4);

            for (int i = 0; i < qtdInimigos; i++)
            {
                GameObject e = Instantiate(inimigos[i]) as GameObject;
                e.transform.position = new Vector2(limitesDaTela.x, Random.Range(-limitesDaTela.y, limitesDaTela.y));
                tempoProximoInimigo += tempoEntreInimigos + qtdInimigos;
            }
        }
    }

    public void SpawnPowerUp()
    {
        GameObject e = Instantiate(powerUp) as GameObject;
        e.transform.position = new Vector2(limitesDaTela.x, Random.Range(-limitesDaTela.y, limitesDaTela.y));
    }

    public void SpawnBoss()
    {
        if (!instanciouChefe)
        {
            GameObject e = Instantiate(boss) as GameObject;
            // e.transform.position = new Vector2(limitesDaTela.x, 0);
            instanciouChefe = true;
        }
    }
}
