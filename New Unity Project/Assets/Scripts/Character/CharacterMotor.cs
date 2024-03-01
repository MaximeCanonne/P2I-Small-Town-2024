using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotor : MonoBehaviour
{
    private PlayerInput Inputs;

    private InputAction moveAction;

    private Animator Anim;

    private GameManager Manager;

    private Vector2 velocity = Vector2.zero;
    private int Direction = 0;

    [SerializeField]
    private float speed = 5f;

    public static CharacterMotor Instance;

    private Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Manager = GameManager.GetInstance();
        Inputs = Manager.GetInputs();
        Anim = GetComponent<Animator>();

        moveAction = Inputs.actions.FindAction("Move");

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Désactive la gravité pour éviter de tomber vers le bas
    }

    private void FixedUpdate()
    {
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();
        _moveValue = ChooseDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(
            velocity.x * Time.fixedDeltaTime,
            velocity.y * Time.fixedDeltaTime,
            0
        );

        // Animation
        Anim.SetInteger("direction", Direction);
    }

    private Vector2 ChooseDirection(Vector2 _value)
    {
        Vector2 _result = Vector2.zero;
        if (Mathf.Abs(_value.x) >= Mathf.Abs(_value.y)) // D�placements horiztonaux
        {
            _result = new Vector2(_value.x, 0);
        }
        else
        {
            _result = new Vector2(0, _value.y);
        }

        Direction = SetDirection(_result);
        return _result;
    }

    private int SetDirection(Vector2 _vector)
    {
        if (_vector.x > 0)
        {
            return 6;
        }
        if (_vector.x < 0)
        {
            return 4;
        }
        if (_vector.y > 0)
        {
            return 8;
        }
        if (_vector.y < 0)
        {
            return 2;
        }
        return 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("YAAAAA00");
            // Collision avec un obstacle, empêcher le mouvement
            speed = 0f;
        }
    }
}
