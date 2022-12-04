using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Run = "Run";

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radius;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(Run, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            int negativeDirection = -1;
            transform.Translate(_speed * Time.deltaTime * negativeDirection, 0, 0);
            _animator.SetBool(Run, true);
        }
        else
        {
            _animator.SetBool(Run, false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround() == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private bool OnGround()
    {
        bool onGround = Physics2D.OverlapCircle(_groundCheck.position, _radius, _ground);
        return onGround;
    }
}
