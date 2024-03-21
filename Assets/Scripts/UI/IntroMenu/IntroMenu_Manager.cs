using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject blackScreen, titulo, textoBoton, camara;
    private void Start()
    {
        blackScreen.SetActive(true);
    }
    public void IniciarJuego()
    {
        Debug.Log("IniciarJuego()");
        StartCoroutine(StartAnim());
    }
    IEnumerator StartAnim()
    {
        Debug.Log("StartAnim()");
        blackScreen.GetComponent<Animator>().SetBool("start", true);
        camara.GetComponent<Animator>().SetBool("start", true);
        titulo.GetComponent<Animator>().SetBool("start", true);
        textoBoton.GetComponent<Animator>().SetBool("start", true);
        yield return new WaitForSeconds(0.9f);
        Debug.Log("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
