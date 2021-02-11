﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    private int light_value = 200;
    public GameObject obj;
    private int enemy_value = -500;
   
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        //picking up light items
        if (col.gameObject.tag == "Item_light")
        {

            col.gameObject.SetActive(false);
            obj.GetComponent<ChangingNumber>().AddToNumber(light_value);
        }
        //meeting enemy
        else if (col.gameObject.tag == "enemy")
        {
            obj.GetComponent<ChangingNumber>().AddToNumber(enemy_value);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

    }

}
