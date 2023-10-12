using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator ani;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float sprintMultiplier = 3;

    bool isSprinting;
    Vector2 movement;
    float finalSpeed;

    GameObject nearestInteractable;

    private void Update()
    {
        HandleMovement();
        HandleControls();
    }

    void HandleControls()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //Open Shop
            if (nearestInteractable != null)
            {
                View.GetView<ClothShopView>().InitializeShop();
            }
        }
    }

    void FixedUpdate()
    {
        finalSpeed = moveSpeed * (isSprinting == false ? 1 : sprintMultiplier);
        rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        nearestInteractable = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        nearestInteractable = null;
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");  

        HandleAnimation(movement);

        //Flip Sprite for Animation
        sr.flipX = movement.x < 0 || ani.GetBool("Face Left") == true ? true : false;

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
