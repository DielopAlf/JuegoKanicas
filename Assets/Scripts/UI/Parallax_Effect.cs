using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Effect : MonoBehaviour
{
    Vector2 startPosition;
    [SerializeField]
    int moveModifier;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        Vector2 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float posX = Mathf.Lerp(transform.position.x, startPosition.x + (pz.x * moveModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, startPosition.y + (pz.y * moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
