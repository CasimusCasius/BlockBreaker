using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int pointsPerBlockDostroyed = 50;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGameStatus()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDostroyed;
        DisplayScore();
    }
}
