using TMPro;
using UnityEngine;

public class ScoreText : MonoCache
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform player;
    public int currentScore { get; private set; }

    private void Start()
    {
        Show();
        scoreText.text = "0"; 
    }

    public override void OnTick()
    {
        if (currentScore < (int)(player.position.y / 0.7f))
        {
            scoreText.text = ((int)(player.position.y / 0.7f)).ToString();
            currentScore = (int)(player.position.y / 0.7f);
        }
        else
        {
            return;
        }
    }

    public void Hide()
    {
        scoreText.gameObject.SetActive(false);
    }

    private void Show()
    { 
        scoreText.gameObject.SetActive(true);
    }
}
