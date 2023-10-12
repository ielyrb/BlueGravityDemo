using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float sprintMultiplier = 3;

    bool isSprinting;
    Vector2 movement;
    float finalSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        finalSpeed = moveSpeed * (isSprinting == false ? 1 : 5);
        rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log(movement.x);
        Debug.Log(movement.y);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }
}
