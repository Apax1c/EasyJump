using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";
    private const string PLAYER_PREFS_BEST_SCORE = "BestScore";

    [SerializeField] private ScoreText inGameScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private GameObject background;

    private void Start()
    {
        SphereBounce.Instance.OnGameOvered += SphereBounce_OnGameOvered;
    }

    private void SphereBounce_OnGameOvered(object sender, EventArgs e)
    {
        background.SetActive(true);
        currentScoreText.text = "Score: " + inGameScoreText.currentScore.ToString();
        inGameScoreText.Hide();

        SetNewBestScore(inGameScoreText.currentScore);
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt(PLAYER_PREFS_BEST_SCORE).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(GAME_SCENE);
    }

    private void SetNewBestScore(int newBestScore)
    {
        int currentBestScore = PlayerPrefs.GetInt(PLAYER_PREFS_BEST_SCORE, 0);
        if (currentBestScore < newBestScore)
        {
            PlayerPrefs.SetInt(PLAYER_PREFS_BEST_SCORE, newBestScore);
            PlayerPrefs.Save();
        }
    }
}
