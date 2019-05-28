using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Configuration Parameters

    [SerializeField]
    private float screenWidthInUnits = 16f;

    [SerializeField]
    private float minXUnits = 0.88f;

    [SerializeField]
    private float maxXUnits = 15.22f;

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
	    paddlePos.x = Mathf.Clamp(mousePosInUnits, minXUnits, maxXUnits);
	    transform.position = paddlePos;
	}
}
