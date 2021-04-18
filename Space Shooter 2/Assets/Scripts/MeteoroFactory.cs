using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> meteoros;

    float tProximoMeteoro = 0;

    Vector2 limitesDaTela;

    void Start()
    {
        limitesDaTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tProximoMeteoro)
        {
            tProximoMeteoro = Time.time + Random.Range(0.5f, 1.5f);

            int numInimigos = Random.Range(0, meteoros.Count);

            for (int i = 0; i < numInimigos; i++)
            {
                GameObject meteoro = Instantiate(meteoros[Random.Range(0, meteoros.Count)]);
                meteoro.transform.position = new Vector2(
                    meteoro.transform.position.x, 
                    Random.Range(-limitesDaTela.y, limitesDaTela.y)
                );
            }
        }
    }
}
