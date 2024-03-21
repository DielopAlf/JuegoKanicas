using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaBehavior_Custom : MonoBehaviour
{
    public Vector3[] points;
    int current;
    public float speed_m;
    bool palanca;
    bool palancaInteraction;
    public GameObject[] door;

    private void Start()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].transform.position != points[current])
            {
                door[i].transform.position = points[current];
            }
            current = 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shuriken_Launched")
        {
            if (palanca == false)
            {
                palanca = true;
                gameObject.GetComponent<Animator>().SetBool("ON", true);
            }
            else if (palanca == true)
            {
                palanca = false;
                gameObject.GetComponent<Animator>().SetBool("ON", false);
            }
            if (palancaInteraction == false)
            {
                palancaInteraction = true;
            }
        }

    }
    private void Update()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].transform.position != points[current] && palancaInteraction == true)
            {
                //Movement
                door[i].transform.position = Vector3.MoveTowards(door[i].transform.position, points[current], speed_m * Time.deltaTime);
            }
            else if (door[i].transform.position == points[current] && palancaInteraction == true)
            {
                current = (current + 1) % points.Length;
                palancaInteraction = false;
            }
        }
    }
}
