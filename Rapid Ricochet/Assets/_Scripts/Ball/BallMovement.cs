using TMPro;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    [SerializeField] private float InitialSpeed;
    [SerializeField] private float SpeedIncrease;
    [SerializeField] private TextMeshProUGUI LeftTextScore;
    [SerializeField] private TextMeshProUGUI RightTextScore;
    private Rigidbody2D _rb;
    private int hitCounter;
    private int LScore;
    private int RScore;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Invoke("BallStart", 3f);
    }
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, InitialSpeed + (SpeedIncrease + hitCounter));
    }
    private void BallStart()
    {
        var xFlipCoin = Random.Range(0, 2);
        var yFlipCoin = Random.Range(0, 3);
        if (xFlipCoin == 0)
        {
            //left side//
            if(yFlipCoin== 0)
            {
                _rb.velocity = new Vector2(-1, -1) * (InitialSpeed + SpeedIncrease * hitCounter);
            }
            else if (yFlipCoin == 1)
            {
                _rb.velocity = new Vector2(-1, 1) * (InitialSpeed + SpeedIncrease * hitCounter);
            }
            else
            {
                _rb.velocity = new Vector2(-1, 0) * (InitialSpeed + SpeedIncrease * hitCounter);
            }
        }
        else
        {
            //right side//
            if (yFlipCoin ==0)
            {
                _rb.velocity = new Vector2(1, -1) * (InitialSpeed + SpeedIncrease * hitCounter);
            }
            else if(yFlipCoin == 1)
            {
                _rb.velocity = new Vector2(1, 1) * (InitialSpeed + SpeedIncrease * hitCounter);
            }
            else
            {
                _rb.velocity = new Vector2(1, 0) * (InitialSpeed + SpeedIncrease * hitCounter);
            }

        }
    }
    private void BallReset()
    {
        _rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("BallStart", 3f);
    }
    private void BallBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 PlayerPos = myObject.position;

        float XDirection;
        float YDirection;

        if (transform.position.x > 0)
        {
            XDirection = -1;
        }
        else
        {
            XDirection = 1;
        }
        YDirection = (ballPos.y - PlayerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if (YDirection == 0)
        {
            var rd = Random.Range(0, 2);
            if(rd == 0)
            {
                YDirection = 1f;
            }
            else
            {
                YDirection = -1f;
            }
        }
        _rb.velocity = new Vector2(XDirection, YDirection) * (InitialSpeed + (SpeedIncrease * hitCounter));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BallBounce(collision.transform);
        }
        else if (collision.gameObject.CompareTag("Left_Wall"))
        {
            RScore++;
            RightTextScore.text = RScore.ToString();
            BallReset();
        }
        else if (collision.gameObject.CompareTag("Right_Wall"))
        {
            LScore++;
            LeftTextScore.text = LScore.ToString();
            BallReset();
        }
    }
}
