using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Rigidbody2D _rb;
    private Vector2 AiMove;
    [SerializeField] private float AiMovementSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (ball.transform.position.y  > transform.position.y + 0.5f)
        {
            AiMove = new Vector2(0, 1);
        }
        else if(ball.transform.position.y < transform.position.y - 0.5f)
        {
            AiMove = new Vector2(0, -1);
        }
        else
        {
            AiMove = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = AiMove * AiMovementSpeed;
    }
}
