using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    float xMargin = 3f;
    float smoothing = 0.5f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        trackCenter();
    }

    bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - player.transform.position.x) > xMargin;
    }


    void trackCenter()
    {
        //This gets the current position
        float CurX = transform.position.x;
        float NewX = transform.position.x;

        //This only moves the camera is the distance is more then our limits 
        if (CheckXMargin())
        {
            NewX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothing * Time.deltaTime);
        }
        if (NewX < CurX)
        {
            NewX = CurX;
        }

        //This sets the positon of the camera with the new position
        transform.position = new Vector3(NewX, transform.position.y, transform.position.z);
    }

}
