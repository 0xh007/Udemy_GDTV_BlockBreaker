using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Configuration Parameters

    [SerializeField]
    private AudioClip _destroyedSound;

    #endregion

    #region State

    #endregion

    #region Cached References

    private Level _level;

    private GameStatus _gameStatus;

    #endregion

    #region Private Methods

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _gameStatus = FindObjectOfType<GameStatus>();

        _level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(_destroyedSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
        _gameStatus.AddToScore();
    }

    #endregion
}
