using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int Score { get; private set; }
    public float TimeLeft { get; private set; }
    public bool IsPaused;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private int ShiftLengthSeconds;

    void Start()
    {
        if (Instance != null) throw new System.Exception("Only one Game Controller allowed");
        Instance = this;
        TimeLeft = ShiftLengthSeconds;
        gameOverPanel.SetActive(false);
        IsPaused = false;

    }

    private void Update()
    {
        if (IsPaused) return;
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            GameOver();
        }
    }

    public void UpdateScore(int score)
    {
        Score += score;
    }

    private void GameOver()
    {
        IsPaused = true;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
