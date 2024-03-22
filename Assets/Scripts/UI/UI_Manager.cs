using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject blackScreen;
    private void Start()
    {
        blackScreen.SetActive(true);
        StartCoroutine(BlackScreenActive());
    }
    IEnumerator BlackScreenActive()
    {
        yield return new WaitForSeconds(1);
        blackScreen.SetActive(false);
    }
}
