using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    #region State

    [SerializeField]
    private int breakableBlocks;

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

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }

    #endregion
}
