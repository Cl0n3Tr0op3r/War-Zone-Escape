/*
using UnityEngine;
using System.Collections;

public class Follow: MonoBehaviour {
public Transform target;
public float smooth= 5.0f;
void  Update (){
    transform.position = Vector3.Lerp (
        transform.position, target.position,
        Time.deltaTime * smooth);
} 

    } 
    */
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust these values as needed
    public float smooth = 5.0f;

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smooth);
    }
}