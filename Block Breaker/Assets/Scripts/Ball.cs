using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    #region Configuration Parameters

    [SerializeField] private Paddle paddle1;

    [SerializeField] private float xPush = 2f;
        
    [SerializeField] private float yPush = 15f;

    [SerializeField] private AudioClip[] ballSounds;

    [FormerlySerializedAs("randomFactor")]
    [SerializeField]
    private float randomFactorHigh = 0.2f;

    [SerializeField] private float randomFactorLow = -0.2f;

    #endregion

    #region State

    private Vector2 _paddleToBallVector;

    private bool _hasStarted;

    #region Cached Component References

    private AudioSource _myAudioSource;

    private Rigidbody2D _myRigidBody2D;

    #endregion

    #endregion

    // Use this for initialization
    void Start ()
    {
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
            _myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        var position = paddle1.transform.position;
        var paddlePos = new Vector2(position.x, position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var randomX = Random.Range(randomFactorLow, randomFactorHigh);
        var randomY = Random.Range(randomFactorLow, randomFactorHigh);
        var velocityTweak = new Vector2(randomX, randomY);
        
        if (_hasStarted)
        {
            var audioClip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(audioClip);
            _myRigidBody2D.velocity += velocityTweak;
        }
    }
}
