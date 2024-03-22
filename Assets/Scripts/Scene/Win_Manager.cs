using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    float currentLVL;
    string[] split;
    string nombre;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(NextLVL());
        }
    }
    IEnumerator NextLVL()
    {
        Destroy(player.GetComponent<MeshRenderer>());
        player.GetComponent<SphereCollider>().enabled = false;
        player.GetComponent<PlayerMovement_Custom>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
        //Wich one is the current LVL:
        yield return new WaitForSeconds(2);
        
        nombre = SceneManager.GetActiveScene().name;
        split = nombre.Split('-');
        currentLVL = float.Parse(split[1]);
        Debug.Log(currentLVL);


        //Load next LVL:
        int buildIndex = SceneUtility.GetBuildIndexByScenePath("LVL-" + (currentLVL + 1));
        if (buildIndex != -1)
        {
            SceneManager.LoadScene("LVL-" + (currentLVL + 1));
            Debug.Log("Next LVL is: " + "LVL-" + (currentLVL + 1));
        }
        else if (buildIndex == -1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
