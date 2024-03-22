using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    /*[SerializeField]
    GameObject canvas;*/

    private GameObject player;

    [SerializeField]
    GameObject ememy, alert, smoke;

    public int walls;

    Vector3 lastPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            lastPos = other.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(ememy.transform.position + (Vector3.down * 0.3f), (player.transform.position + (Vector3.down * 0.3f) - ememy.transform.position + (Vector3.down * 0.3f)), out hit, Vector3.Distance(player.transform.position, ememy.transform.position), Physics.AllLayers))
            {
                if (hit.collider.gameObject.layer != walls)
                {
                    StartCoroutine(DeathConsecuences());
                }
            }
        }
    }
    IEnumerator DeathConsecuences()
    {
        Instantiate(smoke, player.transform.position, Quaternion.identity);
        alert.SetActive(true);
        Destroy(player.GetComponent<MeshRenderer>());
        player.GetComponent<SphereCollider>().enabled = false;
        player.GetComponent<PlayerMovement_Custom>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
        player.transform.position = lastPos;
        //canvas.SetActive(false);
        yield return new WaitForSeconds(2);
        player.transform.position = lastPos;
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
