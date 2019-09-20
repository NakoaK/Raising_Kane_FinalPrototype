using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject background;
    private float backgroundWidth = 20;
    private Vector3 CurrBackground;
    private bool NextSpawned = true;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CurrBackground = new Vector3(transform.position.x, transform.position.y, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            if (player.transform.position.x > (CurrBackground.x + (backgroundWidth/4)))
            {
                Vector3 newPosition = new Vector3(CurrBackground.x + backgroundWidth, CurrBackground.y, 0);
                CurrBackground = newPosition;

                Instantiate(background, newPosition, Quaternion.identity);
            }
        
    }
}