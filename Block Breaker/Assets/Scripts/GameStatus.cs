using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    #region Configuration parameters

    [Range(0.1f, 10f)]
    [SerializeField]
    private float _gameSpeed = 1f;

    [SerializeField]
    private int _pointsPerBlockDestroyed = 83;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    #endregion

    #region State

    [SerializeField]
    private int _currentScore = 0;

    #endregion

    #region Private Methods

    private void Start()
    {
        _scoreText.text = _currentScore.ToString();
    }

	private void Update ()
    { 
	    Time.timeScale = _gameSpeed;
	}

    #endregion

    #region Public Methods

    public void AddToScore()
    {
        _currentScore += _pointsPerBlockDestroyed;
        _scoreText.text = _currentScore.ToString();
    }

    #endregion
}
