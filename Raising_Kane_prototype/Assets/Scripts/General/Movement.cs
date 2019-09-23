using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb2d;
    public Transform pos;
    public int speed;

    public HealthBar HB;
    public GameObject HbInner;
    public GameObject HbOuter;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        pos = player.GetComponent<Transform>();
        HB = new HealthBar(20);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curMov = new Vector2();
        rb2d.GetVector(curMov);
        curMov.x = -curMov.x;
        curMov.y = -curMov.y;
        rb2d.AddForce(curMov); 
        

        //Basic Movement
        Vector2 movement = new Vector2();

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

        rb2d.AddForce(movement);

        if(Input.GetKey(KeyCode.Q))
        {
            HB.DamageHealth(1);
        }

        UpdateHealth();

    }


    bool checkEdge(Vector2 edge)
    {
        if (pos.position.y < edge.y)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    bool checkEdge2(Vector2 edge)
    {
        if (pos.position.y > edge.y)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    void UpdateHealth()
    {
        Vector3 curScale = HbInner.transform.localScale;
        curScale.x = HB.GetHealthPercent();
        HbInner.transform.localScale = curScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}



