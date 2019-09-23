using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Boss Scene");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Boss_Sleep");
        }
    }
}
