using UnityEngine;
using UnityEngine.Serialization;

public class Block : MonoBehaviour
{
    #region Configuration Parameters

    [FormerlySerializedAs("_destroyedSound")] [SerializeField]
    private AudioClip destroyedSound;

    [FormerlySerializedAs("_blockSparksVfx")] [SerializeField]
    private GameObject blockSparksVfx;

    [FormerlySerializedAs("_hitSprites")] [SerializeField]
    private Sprite[] hitSprites;

    #endregion

    #region State

    [FormerlySerializedAs("_timesHit")] [SerializeField]
    private int timesHit;

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

    private void OnCollisionEnter2D()
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        var maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
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
        var spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(destroyedSound, Camera.main.transform.position);
        }
        Destroy(gameObject);
        _level.BlockDestroyed();
        _gameStatus.AddToScore();
        TriggerSparklesVfx();
    }

    private void TriggerSparklesVfx()
    {
        var transform1 = transform;
        var sparkles = Instantiate(blockSparksVfx, transform1.position, transform1.rotation);
        Destroy(sparkles, 1f);
    }

    #endregion
}
