using UnityEngine;
class PlayerLifeManager : LifeManager
{
    public override void AddLife(int life)
    {
        base.AddLife(life);
        GameController.SharedInstance.AtualizarLifePlayer(currentLife);
    }

    protected override void Morrer()
    {
        Destroy(gameObject);
        GameObject e = Instantiate(explosao) as GameObject;
        e.transform.position = transform.position;
        GameController.SharedInstance.MostrarGameOver();
    }
}