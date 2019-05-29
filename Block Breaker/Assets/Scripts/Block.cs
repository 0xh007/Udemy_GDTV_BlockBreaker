using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Configuration Parameters

    [SerializeField]
    private AudioClip _destroyedSound;

    [SerializeField]
    private GameObject _blockSparksVfx;

    [SerializeField]
    private Sprite[] _hitSprites;

    #endregion

    #region State

    [SerializeField]
    private int _timesHit;

    #endregion

    #region Cached References

    private Level _level;

    private GameStatus _gameStatus;

    #endregion

    #region Private Methods

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        _gameStatus = FindObjectOfType<GameStatus>();

        if (gameObject.CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        _timesHit++;
        int _maxHits = _hitSprites.Length + 1;

        if (_timesHit >= _maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        var spriteIndex = _timesHit - 1;
        if (_hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = _hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(_destroyedSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
        _gameStatus.AddToScore();
        TriggerSparklesVfx();
    }

    private void TriggerSparklesVfx()
    {
        var sparkles = Instantiate(_blockSparksVfx, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    #endregion
}
