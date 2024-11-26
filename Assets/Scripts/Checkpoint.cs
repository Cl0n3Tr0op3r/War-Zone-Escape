using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < dead)
        {
            player.transform.position = vectorPoint;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;

        // Hide the object instead of destroying it
        other.gameObject.SetActive(false); // Deactivates the object completely
        
        // Alternatively, disable specific components (like Renderer and Collider)
        // other.GetComponent<Renderer>().enabled = false; // Hides the object visually
        // other.GetComponent<Collider>().enabled = false; // Disables interaction
    }
}
