using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip walkingSound;   // Walking sound clip
    private bool isWalking = false;  // Whether the player is moving

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();  // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast to check if the player is grounded and adjust position
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            Vector3 movePos = transform.position;
            movePos.y = hit.point.y + groundDist;
            transform.position = movePos;
        }

        // Movement and sprite flipping
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }

        // Check if the player is moving
        bool isMoving = (x != 0 || y != 0);

        // Play walking sound if the player is moving and the sound isn't already playing
        if (isMoving && !isWalking)
        {
            isWalking = true;
            audioSource.clip = walkingSound;
            audioSource.Play();
        }
        // Stop walking sound if the player is not moving
        else if (!isMoving && isWalking)
        {
            isWalking = false;
            audioSource.Stop();
        }
    }
}
