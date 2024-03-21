using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerMovement_Custom : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    //BallBounce:
    #region
    Vector3 lastVelocity;

    private void OnCollisionEnter(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //BallBounce:
        #region
        lastVelocity = rb.velocity;
        #endregion

        if (rb.velocity.x <= 0.4f && rb.velocity.x > -0.4f && rb.velocity.z <= 0.4f && rb.velocity.z > -0.4f)
        {
            isShoot = false;
        }
    }

    private void OnMouseDown()
    {
        mousePressDownPos = new Vector3(Input.mousePosition.x / 1920, Input.mousePosition.y / 1080, 0);
    }

    private void OnMouseUp()
    {
        mouseReleasePos = new Vector3(Input.mousePosition.x / 1920, Input.mousePosition.y / 1080, 0);
        Shoot(mousePressDownPos - mouseReleasePos);
        StartCoroutine(IsShoot());
    }
    IEnumerator IsShoot()
    {
        yield return new WaitForSeconds(0.05f);
        isShoot = true;
    }

    private float forceMultiplier = 10000;
    void Shoot(Vector3 Force)
    {
        if (this.isActiveAndEnabled)
        {
            if (isShoot == false)
            {
                rb.AddRelativeForce(new Vector3(Force.x, Force.z, Force.y) * forceMultiplier);
            }
        }
    }
}
