using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SwitchBG : MonoBehaviour
{

    public SpriteRenderer background;
    public Sprite oneSheet;
    public Sprite Anim1;
    public Sprite Anim2;
    public Sprite Anim3;
    public Sprite Anim4;



    // Start is called before the first frame update
    void Start()
    {
        background.sprite = oneSheet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            background.sprite = Anim1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            background.sprite = Anim2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            background.sprite = Anim3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            background.sprite = Anim4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            background.sprite = oneSheet;
        }

    }
           
}
