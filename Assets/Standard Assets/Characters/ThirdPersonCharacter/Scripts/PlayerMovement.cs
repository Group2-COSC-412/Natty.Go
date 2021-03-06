﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    public GameObject gameSettings;

    public enum powerUp
    {
        NONE,
        SPEED,
        WIND,
        INVINCIBILITY
    }

    // Movement ids
    public readonly int MOVE_FORWARD = 0;
    public readonly int MOVE_RIGHT = 1;
    public readonly int MOVE_DOWN = 2;
    public readonly int MOVE_LEFT = 3;

    public static KeyCode[] player1Movement = new KeyCode[] {
        KeyCode.UpArrow,
        KeyCode.RightArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow
    };

    public static KeyCode[] player2Movement = new KeyCode[] {
        KeyCode.W,
        KeyCode.D,
        KeyCode.S,
        KeyCode.A
    };

    //speeds
    public float MOVEMENT_SPEED = 2;
    public float MOVEMENT_FRICTION = 3;
    public float MAX_SPEED = 1;

    //effects
    public float PLAYER_RADIUS = 5;
    public float PLAYER_WIND_RADIUS = 2;
    public float PLAYER_PARTICLE_RADIUS = 3;
    public float PLAYER_PARTICLE_WIND_RADIUS = 1.5f;
    public int PLAYER_EMIT_WIND = 50;
    public int PLAYER_EMIT = 1000;

    public int playerNumber = 0;
    public KeyCode[] thisMovement;

    public float xVel = 0;
    public float yVel = 0;
    public float zVel = 0;

    public powerUp myPowerUp = powerUp.NONE;
    public float timer;


    // Use this for initialization
    public virtual void Start()
    {

        if (gameSettings == null) {
            gameSettings = GameObject.Find("_Scripts");
        }

        if (playerNumber == 0)
        {
            thisMovement = player1Movement;
        }
        else
        {
            thisMovement = player2Movement;
        }

    }
        

    // Update is called once per frame
    public virtual void Update()
    {

        //update colors
        /*if (gameSettings.GetComponent<GameSettings>().playerColors.Length >= 2)
        {
            ParticleSystemRenderer ren = GetComponentInChildren<ParticleSystemRenderer>();
            ren.material.color = ren.trailMaterial.color = gameSettings.GetComponent<GameSettings>().playerColors[playerNumber];
        }*/


        //update speeds
        float tempSpeed = MOVEMENT_SPEED;
        float tempMax = MAX_SPEED;
        if(myPowerUp != powerUp.NONE)
        {
            timer += Time.deltaTime;
        }

        

        int verticalMovement = 0;
        int horizontalMovement = 0;
        int zMovement = 0;

#if UNITY_STANDALONE

        if (Input.GetKey(thisMovement[MOVE_DOWN]))
        {
            zMovement -= 1;
        }

        if (Input.GetKey(thisMovement[MOVE_RIGHT]))
        {
            horizontalMovement += 1;
        }

        if (Input.GetKey(thisMovement[MOVE_LEFT]))
        {
            horizontalMovement -= 1;
        }

        if (Input.GetKey(thisMovement[MOVE_FORWARD]))
        {
            zMovement += 1;
        }
#endif

        //Controls for Android devices
#if UNITY_ANDROID
        Touch touch = Input.GetTouch(0);

        if (!touch.Equals(null))
        {
            horizontalMovement = (int) (touch.deltaPosition.x);
            //verticalMovement = (int)(touch.deltaPosition.y );
            zMovement = (int) (touch.deltaPosition.y);
        }
#endif
        xVel += horizontalMovement * tempSpeed * Time.deltaTime;
        //yVel += verticalMovement * tempSpeed * Time.deltaTime;
        zVel += zMovement * tempSpeed * Time.deltaTime;

        if (horizontalMovement == 0)
        {
            xVel -= Time.deltaTime * MOVEMENT_FRICTION * Mathf.Sign(xVel);
        }
        if (zMovement == 0)
        {
            zVel -= Time.deltaTime * MOVEMENT_FRICTION * Mathf.Sign(yVel);
        }

        if (Mathf.Abs(xVel) > tempMax)
        {
            xVel = tempMax * Mathf.Sign(xVel);
        }

        if (Mathf.Abs(xVel) < 0.2f && horizontalMovement == 0)
        {
            xVel = 0;
        }

        if (Mathf.Abs(zVel) > tempMax)
        {
            zVel = tempMax * Mathf.Sign(yVel);
        }

        if (Mathf.Abs(zVel) < 0.2f && zMovement == 0)
        {
            zVel = 0;
        }

        

        Vector3 move = (Vector3.forward * zVel) + (Vector3.right * xVel);
        //move.Normalize();



        gameObject.transform.Translate(move);

    }

}