using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    float currentLVL;
    string[] split;
    string nombre;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
            StartCoroutine(NextLVL());
        }
    }
    IEnumerator NextLVL()
    {
        //Wich one is the current LVL:
        yield return new WaitForSeconds(2);
        //Debug.Log(SceneManager.GetActiveScene().name);
        nombre = SceneManager.GetActiveScene().name;
        //Debug.Log(SceneManager.GetActiveScene().name);
        split = nombre.Split('-');
        //Debug.Log(split.Length);
        currentLVL = float.Parse(split[1]);
        Debug.Log(currentLVL);
        /*for (int i = 0; i < split.Length; i++)
        {
            Debug.Log("Split " + split[i]);
        }*/


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
