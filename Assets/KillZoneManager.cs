using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneManager : MonoBehaviour
{
    public bool isMovable;
    public int moveSpeed;
    
    Collider2D colliderPart;
    // Start is called before the first frame update
    void Start()
    {
        colliderPart = GetComponent<Collider2D>();
        if (isMovable == false)
        {

            moveSpeed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        

        if (collision.CompareTag("MarkedForDespawn"))
        {
            Destroy(collision.gameObject,.5f);
            Debug.Log("Hey!");
        }
    }

   
    private void Update()
    {
        if (isMovable)
        {
            Vector2 currentPos = transform.position;
            transform.Translate(new Vector2(moveSpeed * Time.deltaTime,0));
        }
    }
}
