using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Boss variables
    public float bossHealth; // 5 hits to kill
    private bool bossAttack;
    private bool asleep;
    public float BOSS_DAMAGE = 200;
    public float distFromBoss;
    public Sprite bossAwake;
    public Sprite bossSleep;
    private SpriteRenderer spr_renderer;


    //Player Variables
    private Transform player;
    //public Animator PLAYER_ANIMATOR;
    private bool playerInRange;
    private bool playerAttacked;
    private float playerHealth;
    private Old_ComboSystem COMBO_SYSTEM;
    

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

        COMBO_SYSTEM = new Old_ComboSystem();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //PLAYER_ANIMATOR = player.GetComponent<Animator>(); 
        asleep = false; //this should be set to false
        bossAttack = false;

        AttackObj.SetActive(false);//assuming this is some way to send damage.
        playerAttacked = false;

        //Sprite Renderer start check
        spr_renderer = GetComponent<SpriteRenderer>();
        if (spr_renderer.sprite == null)
            spr_renderer.sprite = bossAwake; 
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

        switchSprite();

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
        spr_renderer.sprite = bossSleep;
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

    //Boss's health goes up if it's damaged
    private void Unkillable(int damage)
    {
        if (!asleep)
        {
            //anim.SetTrigger("take_damage"); // added this as well
            HB.DamageHealth(damage);
           // musicManager.Playsound("enemyDamaged");
            bossHealth += damage;
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
        if (playerAttacked)
        {
            Unkillable(damage);
        }
    }

    //health bar
    void UpdateHealth()
    {
        Vector3 curScale = HbInner.transform.localScale;
        curScale.x = HB.GetHealthPercent();
        HbInner.transform.localScale = curScale;
    }


    //Switch to other sprite
    void switchSprite()
    {
        
        //Player gets close and does regular combo attacks 
        if (Vector2.Distance(transform.position, player.position) <= distFromBoss && bossAttack == false)
        {
            playerInRange = true;
            spr_renderer.sprite = bossAwake;
        }

        //If player attacks with combos Boss gains health
        if (Vector2.Distance(transform.position, player.position) <= distFromBoss &&
            COMBO_SYSTEM.isAttacking == true && Input.GetKeyDown("space") && bossAttack == true)
        {
            Unkillable(100);
            spr_renderer.sprite = bossAwake;

            timeElapsed = attackDelay;
            bossAttack = true;
            //StartCoroutine(BossAttack(timeElapsed));
        }

        //If Player's far Boss goes to sleep
        /*else if (Vector2.Distance(transform.position, player.position) > distFromBoss 
                 && bossAttack == false && bossAwake)
        {
            playerInRange = false;

            Sleep();
        }*/

        //If Player's close and Hugs instead, Boss goes to sleep and is now killable
        if (Vector2.Distance(transform.position, player.position) <= distFromBoss &&
            COMBO_SYSTEM.isAttacking == false && Input.GetKeyDown("f") && bossAttack == true)
        {
            playerInRange = true;

            Sleep();

            Killable(50);
        }
    }

    IEnumerator BossAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        AttackObj.SetActive(true);

        musicManager.Playsound("enemyAttack");
        print("EnemyAttack");

        yield return new WaitForSeconds(0.5f);
        AttackObj.SetActive(false);
        bossAttack = false;
    }
}
