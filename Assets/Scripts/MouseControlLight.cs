using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlLight : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 sourcePosition;
    float angle;
    Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.position = playerTransform.position;
        sourcePosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = Input.mousePosition;
        mousePos.x = mousePos.x - sourcePosition.x;
        mousePos.y = mousePos.y - sourcePosition.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
