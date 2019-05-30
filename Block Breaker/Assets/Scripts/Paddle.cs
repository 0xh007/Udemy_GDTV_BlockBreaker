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

    // Update is called once per frame
    private void Update () {
	    var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
	    var position = transform.position;
	    var paddlePos = new Vector2(position.x, position.y)
	    {
		    x = Mathf.Clamp(mousePosInUnits, minXUnits, maxXUnits)
	    };
	    position = paddlePos;
	    transform.position = position;
    }
}
