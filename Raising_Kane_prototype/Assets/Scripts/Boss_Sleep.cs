using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sleep : MonoBehaviour
{
    //Boss variables
    public float bossHealth; // 5 hits to kill
    private bool bossAttack;
    private bool asleep;
    public float BOSS_DAMAGE = 200;
    public float distFromBoss;

    //sprites

    public Sprite bossIdle;
    public Sprite bossDamaged;
    public SpriteRenderer bossSpriteRenderer;

    //Player Variables
    private Transform player;
    private bool playerInRange;
    private bool playerAttacked;
    private float playerHealth;


    //creates a Attacking orb???
    public GameObject AttackObj;

    //health bar variables
    HealthBar HB;
    public GameObject HbInner;
    public GameObject HbOuter;

    //attack timer
    private float timeElapsed; //time since last attack
    public float attackDelay; // time delay between attacks


    // Start is called before the first frame update
    void Start()
    {
        HB = new HealthBar(bossHealth);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        asleep = true; //this should be set to false
        bossAttack = false;
        AttackObj.SetActive(false);//assuming this is some way to send damage.
        playerAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        if ((playerInRange == true) && (bossAttack == false))
        {

            timeElapsed = attackDelay;
            bossAttack = true;
            StartCoroutine(BossAttack(timeElapsed));
        }

        if (Vector2.Distance(transform.position, player.position) <= distFromBoss && bossAttack == false)
        {
            playerInRange = true;
        }
        else if (Vector2.Distance(transform.position, player.position) > distFromBoss && bossAttack == false)
        {
            playerInRange = false;
        }

        if (bossHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Turns off attacks and allows the boss to be hit.
    private void Sleep()
    {
        bossAttack = false;
        asleep = true;
    }


    //checks to see if Boss can be damaged
    private void Killable(int damage)
    {
        if (asleep)
        {
            //anim.SetTrigger("take_damage"); // added this as well
            HB.DamageHealth(damage);
            musicManager.Playsound("enemyDamaged");
            bossHealth -= damage;
            print("boss health: " + bossHealth);
        }
        else
        {
            playerAttacked = true;
        }
    }

    //Using the take Damage call from enemy to start the damaging process
    public void TakeDamage(int damage)
    {
        if (!playerAttacked)
        {
            Killable(damage);
        }
        StartCoroutine(BossAttack(0));

        bossSpriteRenderer.sprite = bossDamaged;


        //anim.SetTrigger("take_damage"); // added this as well
        //timeElapsed = stunDelay;
        //Instantiate(bloodeffect, transform.position, Quaternion.identity);
        //play a hurt sound
        /*
        HB.DamageHealth(damage);
        musicManager.Playsound("enemyDamaged");
        bossHealth -= damage;
        print("boss health: " + bossHealth);
        */
    }


    //health bar
    void UpdateHealth()
    {
        Vector3 curScale = HbInner.transform.localScale;
        curScale.x = HB.GetHealthPercent();
        HbInner.transform.localScale = curScale;
    }

    IEnumerator BossAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        bossSpriteRenderer.sprite = bossDamaged;
        musicManager.Playsound("enemyAttack");
        
        yield return new WaitForSeconds(0.3f);
        bossSpriteRenderer.sprite = bossIdle;

        bossAttack = false;
    }
}
