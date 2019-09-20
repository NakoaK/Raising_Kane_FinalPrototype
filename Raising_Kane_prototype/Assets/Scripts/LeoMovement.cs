using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y);

    }
}
