using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameStatus : MonoBehaviour
{
    #region Configuration parameters

    [FormerlySerializedAs("_gameSpeed")]
    [Range(0.1f, 10f)]
    [SerializeField]
    private float gameSpeed = 1f;

    [FormerlySerializedAs("_pointsPerBlockDestroyed")] [SerializeField]
    private int pointsPerBlockDestroyed = 83;

    [FormerlySerializedAs("_scoreText")] [SerializeField]
    private TextMeshProUGUI scoreText;

    #endregion

    #region State

    [FormerlySerializedAs("_currentScore")] [SerializeField]
    private int currentScore = 0;

    private void Awake()
    {
        var gameStatusCount = FindObjectsOfType<GameStatus>().Length; 
        if (gameStatusCount > 1)
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            Destroy(o);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

	private void Update ()
    { 
	    Time.timeScale = gameSpeed;
	}

    #endregion

    #region Public Methods

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    #endregion
}
