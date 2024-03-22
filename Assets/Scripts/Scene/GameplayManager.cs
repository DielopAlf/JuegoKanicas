using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    //private bool CameraON;

    private void Start()
    {
        //player.AddComponent<PlayerMovement_Custom>().enabled = true;
        //Camera.main.GetComponent<CinemachineBrain>().enabled = true;
        PlayerPrefs.DeleteKey("howMany");
    }
    private void Update()
    {
        Debug.Log("how many "+ PlayerPrefs.GetInt("howMany"));
        //Debug.Log("How many shurikens: " + PlayerPrefs.GetInt("howMany"));
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Camera.main.GetComponent<CinemachineBrain>().isActiveAndEnabled == false)
            {
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            }
            else
            {
                Camera.main.GetComponent<CinemachineBrain>().enabled = false;
                Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, player.transform.eulerAngles.y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("MainMenu"); }
    }
}
