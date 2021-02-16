﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingNumber : MonoBehaviour
{
    
    public Text currency; //reference to the UI text object

    private float lightPoints; //the true numerical light value
    private const float STARTING_LIGHT_POINTS = 600; //HAVE TO CHANGE IN CANVAS TOO number of light points the player starts with
    
    //for the animation
    private float currNumber; //currNumber is the currently displayed light value
    private float animationTime = 1.5f;
    private float initial; //goal number is what display is changing to, intial is the start

    //for the timer
    private float timerSpeed = 1f;
    private float elapsed;
    private float lightDecay = 60;

    public List<GameObject> light_objects = new List<GameObject>();
    public void AddToNumber(int value)
    {
        initial = currNumber;
        lightPoints += value;
    }

    public void SubToNumber(int value)
    {
        initial = currNumber;
        lightPoints -= value;
    }

    public void SetToZero()
    {
        initial = currNumber;
        lightPoints = 0;
    }

    //allows other parts of the code to get the current light point value
    public float getLightPts()
    {
        return lightPoints;
    }

    // ticks the currency display up or down on screen
    private void adjustCurrencyDisplay()
    {
        if (lightPoints == STARTING_LIGHT_POINTS)
        {
            currency.text = currNumber.ToString("0");
        }
        else if (currNumber != lightPoints)
        {
            float diff;
            if (initial < lightPoints)
            {
                diff = lightPoints - initial;
                currNumber += (animationTime * Time.deltaTime) * diff;
                if (currNumber >= lightPoints) //erin is assuming this is to account for rounding errors
                    currNumber = lightPoints;
            }
            else
            {
                diff = initial - lightPoints;
                currNumber -= (animationTime * Time.deltaTime) * diff;
                if (currNumber <= lightPoints) //erin is assuming this is to account for rounding errors
                    currNumber = lightPoints;
            }
            if (currNumber <= 0)
            {
                currNumber = 0;
            }
            currency.text = currNumber.ToString("0");
        }
    }

    public void Start()
    {
        lightPoints=STARTING_LIGHT_POINTS;
        currNumber=STARTING_LIGHT_POINTS;
        initial=STARTING_LIGHT_POINTS;

    }


    public void Update()
    {
        if (lightPoints < 0)
        {
            Debug.Log(light_objects.Count);
            for (int i = 0; i < light_objects.Count; i++)
            {
                Debug.Log(light_objects[i]);
                light_objects[i].SetActive(true);
            }
            light_objects.Clear();

            Start();
        }
        //lose light over time
        else
        {
            elapsed += Time.deltaTime; //adds how much time ahs passed
            if (elapsed >= timerSpeed)
            {
                elapsed=0f;
                lightPoints-=lightDecay;
            }
            
        }
        adjustCurrencyDisplay();
    }
}
