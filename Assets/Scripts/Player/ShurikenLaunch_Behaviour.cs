using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ShurikenLaunch_Behaviour : MonoBehaviour
{
    private bool shurikenModeON;

    [SerializeField]
    GameObject shurikenPrefab;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb_s;

    [SerializeField]
    GameObject shurikenSkin;

    [SerializeField]
    GameObject player;

    //SelectShurikenMode:
    #region
    /*public void SelectShurikenMode()
    {
        if (PlayerPrefs.GetInt("howMany") >= 1(Shuriken))
        {
            gameObject.GetComponent<PlayerMovement_Custom>().enabled = false;
            shurikenSkin.SetActive(true);
            shurikenModeON = true;
        }
    }*/
    #endregion
    private void Start()
    {
        shurikenModeON = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Activara shuriken mode:
            if (shurikenModeON == false)
            {
                if (PlayerPrefs.GetInt("howMany") >= 1/*(Shuriken)*/)
                {
                    player.GetComponent<PlayerMovement_Custom>().enabled = false;
                    shurikenSkin.SetActive(true);
                    shurikenModeON = true;
                }
            }
            //Desactivar shuriken mode:
            else if (shurikenModeON == true)
            {
                player.GetComponent<PlayerMovement_Custom>().enabled = true;
                shurikenSkin.SetActive(false);
                shurikenModeON = false;
            }
        }
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if (shurikenModeON == true)
        {
            Instantiate(shurikenPrefab, gameObject.transform.localPosition /*+ player.transform.forward*/, gameObject.transform.localRotation);
            rb_s = GameObject.FindGameObjectWithTag("Shuriken").GetComponent<Rigidbody>();

            mouseReleasePos = Input.mousePosition;
            Shoot(mousePressDownPos - mouseReleasePos);

            //Shuriken lanzado:
            PlayerPrefs.SetInt("howMany", PlayerPrefs.GetInt("howMany") - 1);
            GameObject.FindGameObjectWithTag("Shuriken").tag = "Shuriken_Launched";

            //Desactivar modo después de lanzar:
            shurikenSkin.SetActive(false);
            player.GetComponent<PlayerMovement_Custom>().enabled = true;
            shurikenModeON = false;
        }
    }

    public float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        Vector3 ForceN = Force.normalized;
        rb_s.AddRelativeForce(new Vector3(ForceN.x, ForceN.z, ForceN.y) * forceMultiplier);
    }
}
