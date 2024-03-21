using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObjects : MonoBehaviour
{
    public static UnlockObjects instance;

    [SerializeField]
    public string[] objects;
    [SerializeField]
    public int wichObject;
    [SerializeField]
    public int howMany;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Has recogido " + howMany + " " + objects[wichObject]);
            Destroy(this.gameObject);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("howMany", howMany);
        }
    }
}
