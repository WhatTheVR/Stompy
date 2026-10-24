using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerPhysics;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite moving;
    [SerializeField] private float forceAmount = 10.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPhysics.AddForce(Vector2.left * forceAmount);
            spriteRenderer.flipX = true;  // Facing Left
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPhysics.AddForce(Vector2.right * forceAmount);
            spriteRenderer.flipX = false; // Facing Right
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = moving;
        }
        else
        {
            spriteRenderer.sprite = idle;
        }
    }
}
