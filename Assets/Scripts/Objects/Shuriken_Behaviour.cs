using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken_Behaviour : MonoBehaviour
{
    GameObject enemigoAtacado;
    [SerializeField]
    int rebotes = 2;

    //BallBounce:
    #region
    private Rigidbody rb;
    Vector3 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CheckifMoving());
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    IEnumerator CheckifMoving()
    {
        yield return new WaitForSeconds(0.1f);
        if (rb.velocity == Vector3.zero)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        //BallBounce:
        #region
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
        #endregion

        //Nº rebotes:
        rebotes--;
        if (rebotes <= 0)
        {
            Destroy(this.gameObject);
        }

        //Matar enemigos:
        if (collision.gameObject.tag == "Enemigo")
        {
            enemigoAtacado = collision.gameObject;
            StartCoroutine(EnemyDeath());
            Destroy(this.gameObject);
        }

        //Accionar interruptores:
        //hecho en palanca behaviour.
    }
    IEnumerator EnemyDeath()
    {
        enemigoAtacado.GetComponent<EnemyMovement>().enabled = false;
        Destroy(enemigoAtacado);
        //enemigoAtacado.gameObject.transform.Translate(Vector3.down * 2);
        yield return null;
    }
}
