using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D outro)
    {
        outro.gameObject.GetComponent<LifeManager>().TomarDano(1);
    }
}
