using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int scoreAtual = 0;

    void Awake()
    {
        instance = this;
    }

    public Text scoreText;

    public Text gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void AtualizarScore(int score)
    {
        scoreAtual += score;
        scoreText.text = "Score: " + scoreAtual;
    }

    public void MostrarGameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
}
