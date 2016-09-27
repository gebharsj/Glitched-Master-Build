using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D rigidPlayer;
    public float speed = 5f;

    [SerializeField]
    private float playerSpeed;

    private bool playerFacingRight;

    // Use this for initialization
    void Start ()
    {
        playerFacingRight = true;

        rigidPlayer = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        HandleMovement(horizontal);

        HandleMovement1(vertical);

        Flip(horizontal);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    private void HandleMovement(float horizontal)
    {
        rigidPlayer.velocity = new Vector2(horizontal * playerSpeed, rigidPlayer.velocity.y);
    }

    private void HandleMovement1(float vertical)
    {
        rigidPlayer.velocity = new Vector2(rigidPlayer.velocity.x, vertical * playerSpeed);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !playerFacingRight || horizontal < 0 && playerFacingRight)
        {
            playerFacingRight = !playerFacingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= 1;

            transform.localScale = theScale;
        }
    }
}
