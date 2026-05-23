using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private Rigidbody rb;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private LayerMask ground;

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb  = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Obstacle.OnObstacleHit += OnCollision;
    }

    private void OnDisable()
    {
        Obstacle.OnObstacleHit -= OnCollision;
    }

    private void OnCollision()
    {
        
    }
    
    
    void FixedUpdate()
    {
        bool isGrounded = Physics.Linecast(transform.position, transform.position - Vector3.up, ground);

        if (isGrounded)
        {
            Vector2 moveVector = move.ReadValue<Vector2>();
            //Debug.Log($"Move Vector: {moveVector}");
            float rotateSpeed = -moveVector.x * turnSpeed * Time.fixedDeltaTime;
            rb.AddTorque(new Vector3(0, rotateSpeed, 0));
        }

        float speedMultiplier = Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y));
        rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
    }
}
