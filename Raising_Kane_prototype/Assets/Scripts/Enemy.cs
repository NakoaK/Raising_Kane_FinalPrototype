using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    //public Rigidbody2D rb2d;

    public float speed;
    public float stop_dist;

    private Transform player;

    //public float stunDelay;

    HealthBar HB;
    public GameObject HbInner;
    public GameObject HbOuter;

    public float attackX;
    public float attackY;


    public EnemySpawner Spawner;
    public GameObject AttackObj;

    private float timeElapsed; //time since last attack
    public float attackDelay; // time delay between attacks
    bool foundPlayer;
    public bool attacking = false;


    public Animator anim; // added this back in and attached the animator to this
    //public gameobject bloodeffect; // just drag particle effect into this spot

    // Start is called before the first frame update
    void Start()
    {
        HB = new HealthBar(3);
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AttackObj.SetActive(false);


        timeElapsed = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();

 

        if (foundPlayer == false && attacking == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } 

        if ((foundPlayer == true) && (attacking == false))
        {

            timeElapsed = attackDelay;
            attacking = true;
            StartCoroutine(Attack());
        }

        if (Vector2.Distance(transform.position, player.position) <= stop_dist && attacking == false)
        {
            foundPlayer = true;
        } else if (Vector2.Distance(transform.position, player.position) > stop_dist && attacking == false)
        {
            foundPlayer = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealth()
    {
        Vector3 curScale = HbInner.transform.localScale;
        curScale.x = HB.GetHealthPercent();
        HbInner.transform.localScale = curScale;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("take_damage"); // added this as well
        //timeElapsed = stunDelay;
        //Instantiate(bloodeffect, transform.position, Quaternion.identity);
        //play a hurt sound
        HB.DamageHealth(damage);
        musicManager.Playsound("enemyDamaged");
        health -= damage;
        print("health: " + health);
    }



    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        AttackObj.SetActive(true);
        musicManager.Playsound("enemyAttack");
        print("EnemyAttack");
        yield return new WaitForSeconds(0.5f);
        AttackObj.SetActive(false);
        attacking = false;
    }
}
