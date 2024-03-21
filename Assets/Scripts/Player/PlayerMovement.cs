using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (rb.velocity.x <= 0.4f && rb.velocity.x > -0.4f && rb.velocity.z <= 0.4f && rb.velocity.z > -0.4f)
        {
            isShoot = false;
        }
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        StartCoroutine(IsShoot());
    }
    IEnumerator IsShoot()
    {
        yield return new WaitForSeconds(0.05f);
        isShoot = true;
    }

    private float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        if (this.isActiveAndEnabled)
        {
            if (isShoot == false)
            {
                rb.AddRelativeForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
            }
        }
    }
}
