using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{

    private PlayerHealth playerHealth;
    public float damage;
    public LayerMask isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        if(playerHealth != null)
        {
            Debug.Log("found the player");
        }
    }

    private void Update()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(this.gameObject.transform.position, new Vector2(2, 2), 0, isPlayer);
        for (int i = 0; i < enemiesHit.Length; i++)
        {
            if (enemiesHit[i].GetComponent<PlayerHealth>() != null)
            {
                enemiesHit[i].GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Running into Something");
        if(collider.gameObject.name == "Player")
        {
            Debug.Log("hit the player");
            playerHealth.TakeDamage(damage);
        }
    }
    
}
