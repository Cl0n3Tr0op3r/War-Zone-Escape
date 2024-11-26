using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint; // UnityEngine.Vector3 is assumed since System.Numerics is not used
    [SerializeField] float dead;

    void Update()
    {
        if (player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        Destroy(other.gameObject);
    }
}
