using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    Melee1,
    Melee2
}

public class ComboSystem : MonoBehaviour
{
    private float timeElapsed; //time since last attack
    public float attackDelay; // time delay between attacks

    public Transform attackCenterR;
    public float attackX;
    public float attackY;
    public LayerMask IsEnemy;

    public Sprite attackSprite1;
    public Sprite attackSprite1_left;
    public Sprite attackSprite2;
    public Sprite attackSprite2_left;
    public Sprite idleSprite;
    public Sprite idleSpriteL;
    public SpriteRenderer playerSpriteRenderer;

    public int damage;
    private float gotSpeed;
    private bool facingRight;
    private bool isAttacking;
    //public Animator attackAnim;

    // COMBO STUFF
    private bool activateTimerToReset;
    private float default_Combo_Timer = .4f;
    private float current_Combo_Timer;
    private ComboState current_Combo_State;
    private bool keyDown;
    private bool keyWasDown;

    // Start is called before the first frame update
    void Start()
    {   //Combo system!
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;


        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        gotSpeed = 0;
        facingRight = true;
        isAttacking = false;

        keyDown = false;
        keyWasDown = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        gotSpeed = this.GetComponent<MovePosition_Test>().GetSpeed();
        if (gotSpeed > 0)
        {
            facingRight = true;
            //attackCenter.Translate(new Vector3(.4f, 0f, 0f), this.gameObject.transform);
            //attackCenter.TransformPoint(new Vector3(-.4f, 0f, 0f));
        }
        else if (gotSpeed < 0)
        {
            facingRight = false;
        }

        if (facingRight && !isAttacking)
        {
            //playerSpriteRenderer.sprite = idleSprite;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!facingRight && !isAttacking)
        {
            //playerSpriteRenderer.sprite = idleSpriteL;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //COMBO STUFF

        if (Input.GetAxis("Attack") == 0.0f)
        {
            keyDown = false;
        }


        ComboAttacks();
        ResetComboState();

        // ORIGINAL ATTACK SCRIPT

        /* if (Input.GetKeyDown(KeyCode.Space))
        {

            if (timeElapsed <= 0) //swapped the two if statements here
            {
                StartCoroutine(AttackAnimCo());
                //playerSpriteRenderer.sprite = attackSprite;
                print("Attack");
                //play sound effect
                //playerAnim.SetTrigger("attack");
                Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackCenterR.position, new Vector2(attackX, attackY), 0, IsEnemy);
                for (int i = 0; i < enemiesHit.Length; i++)
                {
                    if (enemiesHit[i].GetComponent<Enemy>() != null)
                    {
                        enemiesHit[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
            }
            timeElapsed = attackDelay;
        }
        else
        {
            timeElapsed -= Time.deltaTime;
        }
        */
    }



    void ComboAttacks()
    {
        if (Input.GetAxis("Attack") > 0 && keyDown == false)
        {
            keyDown = true;
            if (timeElapsed <= 0 ) //swapped the two if statements here
            {
                current_Combo_State++;
                activateTimerToReset = true;
                current_Combo_Timer = default_Combo_Timer;

                if (current_Combo_State == ComboState.Melee1)
                {
                    StartCoroutine(AttackAnimCo1());
                    Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackCenterR.position, new Vector2(attackX, attackY), 0, IsEnemy);
                    for (int i = 0; i < enemiesHit.Length; i++)
                    {
                        if (enemiesHit[i].GetComponent<Enemy>() != null)
                        {
                            enemiesHit[i].GetComponent<Enemy>().TakeDamage(damage);
                        }
                        if (enemiesHit[i].GetComponent<Boss>() != null)
                        {
                            enemiesHit[i].GetComponent<Boss>().TakeDamage(damage);
                        }
                    }
                }

                if (current_Combo_State == ComboState.Melee2)
                {
                    StartCoroutine(AttackAnimCo2());
                    Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackCenterR.position, new Vector2(attackX, attackY), 0, IsEnemy);
                    for (int i = 0; i < enemiesHit.Length; i++)
                    {
                        if (enemiesHit[i].GetComponent<Enemy>() != null)
                        {
                            enemiesHit[i].GetComponent<Enemy>().TakeDamage(damage);
                        }
                        if (enemiesHit[i].GetComponent<Boss>() != null)
                        {
                            enemiesHit[i].GetComponent<Boss>().TakeDamage(damage);
                        }
                    }
                }
            }
           
        }
        

    }

    

    IEnumerator AttackAnimCo1()
    {
        if (facingRight)
        {
            playerSpriteRenderer.sprite = attackSprite1;
            //attackCenter.TransformPoint(new Vector3(-.4f, 0f, 0f));
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerSpriteRenderer.sprite = attackSprite1;
            //attackCenter.TransformPoint(new Vector3(.4f, 0f, 0f));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        isAttacking = true;
        musicManager.Playsound("Melee1");
        yield return new WaitForSecondsRealtime(.3f);
        isAttacking = false;
        playerSpriteRenderer.sprite = idleSprite;
    }

    IEnumerator AttackAnimCo2()
    {
        if (facingRight)
        {
            playerSpriteRenderer.sprite = attackSprite2;
            //attackCenter.TransformPoint(new Vector3(-.4f, 0f, 0f));
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerSpriteRenderer.sprite = attackSprite2;
            //attackCenter.TransformPoint(new Vector3(.4f, 0f, 0f));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        isAttacking = true;
        musicManager.Playsound("Melee2");
        yield return new WaitForSecondsRealtime(.6f);
        isAttacking = false;
        playerSpriteRenderer.sprite = idleSprite;

        timeElapsed = attackDelay;
         while(attackDelay > 0)
        {
            timeElapsed -= Time.deltaTime;
            if (timeElapsed <= 0)
                break;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCenterR.position, new Vector3(attackX, attackY, 1));
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            if(current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }

     void OnFirstPress(string Axis)
    {

        if (Input.GetAxis(Axis) > 0 && keyWasDown == false)
        {
            keyDown = true;
            keyWasDown = true;
        }
        if (Input.GetAxis(Axis) > 0)
        {

        }
    }
}
