using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoEnemy : MonoBehaviour
{

    public float health;
    public float speed;

    private float timeElapsed;
    public float stunDelay;

    public Animator anim;
    //public gameobject bloodeffect; // just drag particle effect into this spot

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        // if enemy has movement this can be used to "stun" when they get hit
        if (timeElapsed <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            timeElapsed -= Time.deltaTime;
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("take_damage");
        timeElapsed = stunDelay;
        //Instantiate(bloodeffect, transform.position, Quaternion.identity);
        //play a hurt sound
        health -= damage;
        print("health: " + health);
    }
}
