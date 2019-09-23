using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Ran into Something");
        if(collider.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Boss Level");
        }
    }
}
