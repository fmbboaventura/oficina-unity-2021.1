using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController SharedInstance;

    public Text scoreText;

    public Text playerLifeText;

    public Text bossLifeText;

    public GameObject gameOverPanel;

    public GameObject winPanel;

    private int score = 0;

    public GameObject factory;

    public int proximoPowerUp = 100;

    public int spawnBossEm = 1000;

    public GameObject player;

    void Awake()
    {
        SharedInstance = this;
    }

    public void AddScore(int incremento)
    {
        score += incremento;
        scoreText.text = "Score: " + score;

        if (score >= proximoPowerUp) {
            proximoPowerUp = score + proximoPowerUp * 3;
            factory.GetComponent<EntityFactory>().SpawnPowerUp();
        }

        if (score >= spawnBossEm)
        {
            bossLifeText.gameObject.SetActive(true);
            factory.GetComponent<EntityFactory>().SpawnBoss();
        }
    }

    public void MostrarGameOver()
    {
        factory.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Sair()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void AtualizarLifePlayer(int life)
    {
        playerLifeText.text = "Life: " + life;
    }

    public void AtualizarLifeBoss(int life)
    {
        bossLifeText.text = "Boss: " + life;
        if (life <= 0 ) {
            bossLifeText.gameObject.SetActive(false);
            winPanel.SetActive(true);
            player.layer = LayerMask.NameToLayer("Default");
            player.GetComponent<PlayerController>().enabled = false;
        }
    }
}
