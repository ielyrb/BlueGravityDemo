using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator ani;
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
        finalSpeed = moveSpeed * (isSprinting == false ? 1 : sprintMultiplier);
        rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");  

        HandleAnimation(movement);

        //Flip Sprite for Animation
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }

    void HandleAnimation(Vector2 dir)
    {

        ani.SetFloat("Horizontal", dir.x);
        ani.SetFloat("Vertical", dir.y);
        ani.SetFloat("Speed", dir.sqrMagnitude);

        if (dir.x != 0)
        {
            ani.SetBool("Face Left", dir.x < 0 && dir.y == 0);
            ani.SetBool("Face Right", dir.x > 0 && dir.y == 0);
            ani.SetBool("Face Down", false);
            ani.SetBool("Face Up", false);
        }
        else if (dir.y != 0)
        {
            ani.SetBool("Face Down", dir.y < 0 && dir.x == 0);
            ani.SetBool("Face Up", dir.y > 0 && dir.x == 0);
            ani.SetBool("Face Left", false);
            ani.SetBool("Face Right", false);
        }
    }
}
