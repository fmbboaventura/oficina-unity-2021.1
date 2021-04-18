using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            outro.gameObject.GetComponent<LifeManager>().TomarDano(1);
        }
    }
}
