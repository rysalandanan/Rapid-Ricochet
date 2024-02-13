using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _yAxis;
    [SerializeField] private float MovementSpeed;
    public bool isPlayer2;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(!isPlayer2)
        {
            _yAxis = Input.GetAxisRaw("Vertical");
            _rb.velocity = new Vector2(_rb.velocity.x, _yAxis * MovementSpeed);
        }
        else
        {
            _yAxis = Input.GetAxisRaw("Vertical2");
            _rb.velocity = new Vector2(_rb.velocity.x, _yAxis * MovementSpeed);
        }
    }
}
