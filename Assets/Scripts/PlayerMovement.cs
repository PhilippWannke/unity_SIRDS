using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 6.0f;
    // speedBoost gives the player a boost when the horizontal button is pressed for a longer period of time
    //bool speedBoostActive = false;
    float exponentialSpeedGrowth = 1f;


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            //speedBoostActive = true;
            exponentialSpeedGrowth += 0.015f;
        }
        else
        {
            //speedBoostActive = false;
            exponentialSpeedGrowth = 1;
        }

        Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(direction * movementSpeed * Time.deltaTime * exponentialSpeedGrowth, Space.World);

    }
}
