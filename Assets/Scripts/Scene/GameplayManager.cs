using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private bool CameraON;

    private void Start()
    {
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;
        PlayerPrefs.DeleteKey("howMany");
    }
    private void Update()
    {
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
    }
}
