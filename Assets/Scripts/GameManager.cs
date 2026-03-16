using TMPro;
using UnityEngine;
public class GameManager: MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;

        scoreText.text = "Score: " + score;
    }
}
