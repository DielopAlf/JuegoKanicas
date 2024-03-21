using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    private GameObject player;

    [SerializeField]
    GameObject ememy;

    public int walls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
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
        Destroy(player.GetComponent<MeshRenderer>());
        player.GetComponent<SphereCollider>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
        canvas.SetActive(false);
        yield return new WaitForSeconds(2);
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
