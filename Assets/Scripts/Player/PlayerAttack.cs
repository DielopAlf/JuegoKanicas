using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject enemigoAtacado;
    Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.tag == "Enemigo")
        {
            rb.Sleep();
            enemigoAtacado = collision.gameObject;
            StartCoroutine(EnemyDeath());
            rb.WakeUp();
        }
    }
    IEnumerator EnemyDeath()
    {
        enemigoAtacado.gameObject.GetComponent<EnemyMovement>().enabled = false;
        enemigoAtacado.gameObject.transform.Translate(Vector3.down * 2);
        yield return new WaitForSeconds(2.1f);
        Destroy(enemigoAtacado);
    }
}
