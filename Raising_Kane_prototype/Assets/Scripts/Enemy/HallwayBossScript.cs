using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayBossScript : MonoBehaviour
{
    public GameObject Player;
    private MovePosition_Test PlayerMotion;
    private float playerXSpeed;
    private Vector2 movement;
    private Rigidbody2D bossBod;
    //public float speed;
    public GameObject bossAttack;
    private bool faceYourFear;
    private bool braved;

    private bool hasTheBossBeenHugged;
    private GameObject[] deathTallyObj;
    

    // Start is called before the first frame update
    void Start()
    {
        bossBod = this.GetComponent<Rigidbody2D>();
        PlayerMotion = Player.GetComponent<MovePosition_Test>();
        playerXSpeed = 0;
        movement.y = 0;
        movement.x = 0;
        deathTallyObj = GameObject.FindGameObjectsWithTag("DeathCounter");
        braved = false;
        hasTheBossBeenHugged = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerXSpeed = PlayerMotion.GetSpeed();
        
        if(faceYourFear)
        {
            if(!braved)
            {
                if(playerXSpeed >= 0)
                {
                    movement.x = playerXSpeed*1.3f;
                    bossAttack.SetActive(true);
                }
                else
                {
                    braved = true;
                }
            }
            else
            {
                // WIN STATE AREA
                bossAttack.SetActive(false);
                movement.x = 0;
                if(hasTheBossBeenHugged)
                {
                    Destroy(this.gameObject); //BEAT THE BOSS! 
                }
            }
        }
        else
        {
            if(playerXSpeed > 0)
            {
                movement.x = playerXSpeed*1.3f;
                bossAttack.SetActive(true);
            }
            else
            {
                movement.x = 0;
                //bossAttack.SetActive(false);
                if (deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() >= 3)
                {
                    setFaceYourFear(true);
                }
            }
        }
        movement.y = 0;
        bossBod.velocity = movement;
    }


    public bool getFaceYourFear()
    {
        return faceYourFear;
    }
    public void setFaceYourFear(bool facing)
    {
        faceYourFear = facing;
    }

    public void hugTheBoss()
    {
        hasTheBossBeenHugged = true;
    }
}
