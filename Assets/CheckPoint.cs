using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    void Update()
    {
        if(player.transform.position.y < -dead){
            player.transform.position = vectorPoint;
        }
    }
    private void OnTriggerEnter(Collider other){
        vectorPoint = player.transform.position;
        Destroy(other.gameObject);
    }
}

