using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control_PC : MonoBehaviour
{
    //Some configuration
    [Header("Player Configurations")]
    
    [Tooltip("Set jump height")] public float JumpPower;
    [Tooltip("Movement speed for player regardless of directions")]public float moveSpeed;
    [Tooltip("Max Speed for player")] public float maxSpeed;
    [Header("Key Bindings")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jump;
    private Rigidbody2D rb2d;
    private bool atGround;
    bool hasJump;
    bool gameOver;
    GameObject groundDetect;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundDetect = GameObject.Find("GroundDetector");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");

        if (hAxis * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * hAxis * moveSpeed);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (groundDetect)
        {
           bool g =  Physics2D.Linecast(transform.position, groundDetect.transform.position, 1 << LayerMask.NameToLayer("Ground"));
           if (g)
            {
                hasJump = false;
                if (Input.GetKey(jump) && hasJump != true)
                {
                    Debug.Log(hasJump);
                    hasJump = true;
                    
                }
            } else if (g == true)
            {
                hasJump = false;
            }
        }

        if (hasJump == true)
        {
            rb2d.AddForce(new Vector2(0, JumpPower));
            hasJump = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killer"))
        {
            callGO();
        }
    }

    void callGO()
    {
        GameManager.instance.callGameOver();
    }
}
