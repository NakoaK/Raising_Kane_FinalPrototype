using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5.5f;
    public float delay = .005f;

    private bool leftPress = false;
    private bool rightPress = false;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2();

        //Allow a bit of distance on "D" key press before disabling it and renabling "A" key
        if (Input.GetAxis("Horizontal") > 0 && rightPress == false) //&& checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = speed;
            StartCoroutine(KeyPressDelay());
            rightPress = true;
            leftPress = false;
        }
        //Allow a bit of distance on "A" key press before disabling it and renabling "D" key
        if (Input.GetAxis("Horizontal") < 0 && leftPress == false)// && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.x = speed;
            StartCoroutine(KeyPressDelay());
            rightPress = false;
            leftPress = true;
        }
        
    }

    IEnumerator KeyPressDelay()
    {
        rb2d.velocity = movement;
        yield return new WaitForSecondsRealtime(delay);
        
    }
}
