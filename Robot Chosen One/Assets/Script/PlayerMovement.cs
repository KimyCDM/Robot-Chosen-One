using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D RigidBody;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private float HorizontalInput;
    private bool isGrounded;

    public float Speed = 5f;
    public float JumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        RigidBody.velocity = new Vector2(HorizontalInput * Speed, RigidBody.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x, JumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);

    }
}
