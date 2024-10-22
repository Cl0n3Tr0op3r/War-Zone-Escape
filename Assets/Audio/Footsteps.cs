using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps: MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound;

    void Update()
    {
        // Check if any movement keys are pressed
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            // Check if sprint key is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            // No movement, disable both sounds
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }
}