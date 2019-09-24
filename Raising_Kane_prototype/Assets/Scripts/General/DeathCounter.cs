using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCounter : MonoBehaviour
{
    private float deathCount = 0;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DeathCounter");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
            if(SceneManager.GetActiveScene().name != "Running_Boss")
            {
                deathCount = 0;
            }
    }

    public void incrementDeathCount()
    {
        deathCount++;
        Debug.Log("death num incremented " + deathCount);
    }
    public float getDeathCount()
    {
        return deathCount;
    }
}
