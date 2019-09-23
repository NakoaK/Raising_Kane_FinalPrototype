using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float SpawnTimer = 0;
    public float Timer;
    public List<GameObject> Enemies; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnTimer += 1;
        if (SpawnTimer > Timer &&  Enemies.Count < 7)
        {
            SpawnEnemy();
            SpawnTimer = 0;
        }

        getCurrentEnemies();
    }

    void getCurrentEnemies()
    {
        Enemies.Clear();
        foreach ( GameObject Obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Enemies.Add(Obj);
        }

    }


    void SpawnEnemy()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = -0.5f;
        Instantiate(Enemy, newPosition, Quaternion.identity);



    }

    //void Check
}
