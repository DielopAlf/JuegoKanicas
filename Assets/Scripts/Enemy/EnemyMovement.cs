using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3[] points;
    int current;
    public float speed_m, speed_r;
    public float rotationDirection;

    private void Start()
    { 
        if (transform.position != points[current])
        {
            transform.position = points[current];
        }
        current = 0;
    }
    private void Update()
    {
        if (transform.position != points[current])
        {
            //Movement
            transform.position = Vector3.MoveTowards(transform.position, points[current], speed_m * Time.deltaTime);

            //Rotation:
            Vector3 direction = points[current] - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(toRotation.x * rotationDirection, toRotation.y * rotationDirection, toRotation.z * rotationDirection, toRotation.w * rotationDirection), speed_r * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
