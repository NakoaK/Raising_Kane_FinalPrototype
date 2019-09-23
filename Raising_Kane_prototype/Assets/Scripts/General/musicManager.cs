using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public static AudioClip enemyAttack, enemyDamaged, playerHit1, playerHit2, pickup;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemyAttack = Resources.Load<AudioClip>("SFX_enemyAttack");
        enemyDamaged = Resources.Load<AudioClip>("SFX_enemyDamaged");
        playerHit1 = Resources.Load<AudioClip>("SFX_Melee1");
        playerHit2 = Resources.Load<AudioClip>("SFX_Melee2");
        pickup = Resources.Load<AudioClip>("SFX_Pickup");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "enemyAttack":
                audioSrc.PlayOneShot(enemyAttack);
                break;
            case "enemyDamaged":
                audioSrc.PlayOneShot(enemyDamaged);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickup);
                break;
            case "Melee1":
                audioSrc.PlayOneShot(playerHit1);
                break;
            case "Melee2":
                audioSrc.PlayOneShot(playerHit2);
                break;
        }
    }

}

