using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region State

    [SerializeField]
    private int _breakableBlocks;

    #endregion

    #region Cached References

    private SceneLoader _sceneLoader;

    #endregion

    #region Private Methods

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    #endregion

    #region Public Methods

    public void CountBreakableBlocks()
    {
        _breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        _breakableBlocks--;
        if (_breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }

    #endregion
}
