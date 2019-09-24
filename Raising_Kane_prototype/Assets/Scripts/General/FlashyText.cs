using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashyText : MonoBehaviour
{
    //Warning: Forum Code!
 
    private bool loop = true;
    public Text textin;
    private GameObject[] deathTallyObj;
    void Start() 
    {
        deathTallyObj = GameObject.FindGameObjectsWithTag("DeathCounter");
        if(deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() == 0)
        {
            textin.text = "RUN, KANE! RUN!!!";
        }
        else if(deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() == 1)
        {
            textin.text = "RUN??";
        }
        else if(deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() == 2)
        {
            textin.text = "...";
        }
        else if(deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() == 3)
        {
            textin.text = "MAYBE HUGGING IT (F) WOULD WORK...";
        }
        else if(deathTallyObj[0].GetComponent<DeathCounter>().getDeathCount() > 3)
        {
            textin.text = "FACE IT, KANE! YOU GOT THIS! HUG IT (F)!";
        }
        StartCoroutine(FlashLabel());
    }   
 
    public IEnumerator FlashLabel() 
    {
   
        // Fancy pants flash of label on and off   
        while (loop) 
        {
            //Debug.Log("Restarted the loop");
            textin.enabled = true;
            yield return new WaitForSeconds(.5f);
            textin.enabled = false;
            yield return new WaitForSeconds(.5f); 
        }
 
    }
}
