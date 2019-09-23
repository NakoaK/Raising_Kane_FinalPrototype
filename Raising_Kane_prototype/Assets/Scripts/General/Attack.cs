using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeElapsed; //time since last attack
    public float attackDelay; // time delay between attacks

    public Transform attackCenterR;
    public float attackX;
    public float attackY;
    public LayerMask IsEnemy;
    public Sprite attackSprite;
    public Sprite attackSpriteL;
    public Sprite idleSprite;
    public Sprite idleSpriteL;
    public SpriteRenderer playerSpriteRenderer;

    public int damage;
    private float gotSpeed;
    private bool facingRight;
    private bool isAttacking;
    //public Animator attackAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        gotSpeed = 0;
        facingRight = true;
        isAttacking = false;

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

        if(facingRight && !isAttacking)
        {
            //playerSpriteRenderer.sprite = idleSprite;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(!facingRight && !isAttacking)
        {
            //playerSpriteRenderer.sprite = idleSpriteL;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (timeElapsed <= 0) //swapped the two if statements here
            {
                StartCoroutine(AttackAnimCo());
                //playerSpriteRenderer.sprite = attackSprite;
                print("Attack");
                //play sound effect
                musicManager.Playsound("Melee1");
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
        
    }

    IEnumerator AttackAnimCo()
    {
        if (facingRight)
        {
            playerSpriteRenderer.sprite = attackSprite;
            //attackCenter.TransformPoint(new Vector3(-.4f, 0f, 0f));
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerSpriteRenderer.sprite = attackSprite;
            //attackCenter.TransformPoint(new Vector3(.4f, 0f, 0f));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        isAttacking = true;
        yield return new WaitForSecondsRealtime(.3f);
        isAttacking = false;
        playerSpriteRenderer.sprite = idleSprite;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCenterR.position, new Vector3(attackX, attackY, 1));
    }
}
