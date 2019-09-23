using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float health;
    //public Rigidbody2D rb2d;
    
    //private Transform player;

    //public float stunDelay;

    HealthBar HB;
    public GameObject HbInner;
    public GameObject HbOuter;
    
   // public GameObject AttackObj;

    //private float timeElapsed; //time since last attack
    //public float attackDelay; // time delay between attacks
    //bool foundPlayer;
    //public bool attacking = false;


    public Animator anim; // added this back in and attached the animator to this
    //public gameobject bloodeffect; // just drag particle effect into this spot

    // Start is called before the first frame update
    void Start()
    {
        HB = new HealthBar(6);
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);

       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //AttackObj.SetActive(false);


       // timeElapsed = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        if(health <= 0)
        {
            SceneManager.LoadScene("MainScene");
           // Destroy(this.gameObject);
        }
        
       
    }

    void UpdateHealth()
    {
        Vector3 curScale = HbInner.transform.localScale;
        curScale.x = HB.GetHealthPercent();
        HbInner.transform.localScale = curScale;
    }

    public void TakeDamage(float damage)
    {
        //anim.SetTrigger("take_damage"); // added this as well
        //timeElapsed = stunDelay;
        //Instantiate(bloodeffect, transform.position, Quaternion.identity);
        //play a hurt sound
        HB.DamageHealth(damage);
        musicManager.Playsound("enemyDamaged");
        health -= damage;
        print("health: " + health);
    }
}
