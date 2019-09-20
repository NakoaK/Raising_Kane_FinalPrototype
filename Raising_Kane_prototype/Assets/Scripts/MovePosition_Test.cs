using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition_Test : MonoBehaviour

    
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.transform.position(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetAxis("Horizontal") > 0) //&& checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = speed;
        }
        if (Input.GetAxis("Horizontal") < 0)// && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.x = -speed;
        }
        if (Input.GetAxis("Vertical") > 0)// && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.y = speed;
        }
        if (Input.GetAxis("Vertical") < 0)// && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.y = -speed;
        }
        if (Input.GetAxis("Vertical") == 0)// && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.y = 0;
        }
        if (Input.GetAxis("Horizontal") == 0)// && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = 0;
        }
        // movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement;
    }

    void FixedUpdate()
    {
        //moveCharacter(movement);
       // detectMovement();
    } 
    
    public float GetSpeed()
    {
        return Input.GetAxis("Horizontal");
    }

    void moveCharacter(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void detectMovement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
