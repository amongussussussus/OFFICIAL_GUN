using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    //Player basic control. Mainly use for testing purpose.
    [SerializeField]
    Rigidbody2D player;
    [SerializeField]
    float maxMoveSpeed;
    [SerializeField]
    float moveForce;
    [SerializeField]
    float jumpForce;
    bool isGroundTouched=false;
    InputAction input;
    void Start()
    {
        input = InputSystem.actions.FindAction("Move");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movingDirection = input.ReadValue<Vector2>();
        if(-maxMoveSpeed <= player.linearVelocityX && player.linearVelocityX <= maxMoveSpeed)
        {
            player.AddForceX(movingDirection.x * moveForce);
        }
        if(movingDirection.y > 0 && isGroundTouched == true)
        {
            //player.linearVelocityY = movingDirection.y * jumpForce;
            player.AddForceY(movingDirection.y * jumpForce,ForceMode2D.Impulse);
            isGroundTouched = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGroundTouched = true;
            Debug.Log("Ground touched");
        }
    }
}
