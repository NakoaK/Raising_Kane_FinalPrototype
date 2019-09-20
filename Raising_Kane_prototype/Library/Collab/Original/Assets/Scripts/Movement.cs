using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb2d;
    public Transform pos;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pos = player.GetComponent<Transform>();
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

        if (Input.GetAxis("Horizontal") > 0)// && checkEdge(new Vector2(-7.5f, 3.5f)))
        {
            movement.x = speed;
        }
        if (Input.GetAxis("Horizontal") < 0 && checkEdge(new Vector2(-7.5f, 3.5f)))
        {
            movement.x = -speed;
        }
        if (Input.GetAxis("Vertical") > 0 && checkEdge(new Vector2(-7.5f, 3.5f)))
        {
            movement.y = speed;
        }
        if (Input.GetAxis("Vertical") < 0)// && checkEdge(new Vector2(-7.5f, 3.5f)))
        {
            movement.y = -speed;
        }

        depthScaling();
        rb2d.AddForce(movement);

    }

    void depthScaling()
    {
        Vector3 scale = new Vector3(1, 1, 1);
        float baseScale = 3;
        if (pos.position.y > 0)
        {
            float scalefactor = 3 - pos.position.y;
            scale = new Vector3(baseScale * scalefactor, baseScale * scalefactor, baseScale * scalefactor);
        }
        else if (pos.position.y < 0)
        {
            float scalefactor = 3 - pos.position.y;
            scale = new Vector3(baseScale * scalefactor, baseScale * scalefactor, baseScale * scalefactor);

        }
        scale.x = Mathf.Clamp(scale.x, 1, 15);
        scale.y = Mathf.Clamp(scale.y, 1, 15);
        scale.z = Mathf.Clamp(scale.z, 1, 15);

        pos.localScale = scale;
    }

    bool checkEdge(Vector2 edge)
    {
        if (pos.position.x > edge.x && pos.position.y < edge.y)
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
        if (pos.position.x > edge.x && pos.position.y < edge.y)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
}

