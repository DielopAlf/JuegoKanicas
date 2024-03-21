using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject blackScreen, botones, ajustes, niveles;
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
    public void LVLSelection()
    {
        if (ajustes.activeInHierarchy == true) { ajustes.SetActive(false); /*botones.SetActive(false);*/ }
        if (niveles.activeInHierarchy == false) { niveles.SetActive(true); /*botones.SetActive(false);*/ }
        else { niveles.SetActive(false); /*botones.SetActive(true);*/ }
    }
    public void Ajustes()
    {
        if (niveles.activeInHierarchy == true) { niveles.SetActive(false); /*botones.SetActive(false);*/ }
        if (ajustes.activeInHierarchy == false) { ajustes.SetActive(true); /*botones.SetActive(false);*/ }
        else { ajustes.SetActive(false); /*botones.SetActive(true);*/ }
    }
    public void Nivel(int nivel)
    {
        SceneManager.LoadScene("LVL-" + nivel.ToString());
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
