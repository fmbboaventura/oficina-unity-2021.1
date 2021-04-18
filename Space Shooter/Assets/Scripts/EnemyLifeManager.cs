using UnityEngine;
class EnemyLifeManager : LifeManager
{
    protected override void Morrer()
    {
        Destroy(gameObject);
        GameObject e = Instantiate(explosao) as GameObject;
        e.transform.position = transform.position;
        GameController.SharedInstance.AddScore(10);
    }
}