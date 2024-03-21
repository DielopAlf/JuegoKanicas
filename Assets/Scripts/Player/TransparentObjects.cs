using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pared")
        {
            other.transform.position += Vector3.down * 1.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pared")
        {
            other.transform.position += Vector3.up * 1.5f;
        }
    }
}
