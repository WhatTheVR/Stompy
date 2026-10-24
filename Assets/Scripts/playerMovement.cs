using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerPhysics;
    [SerializeField] private ParticleSystem walkDust;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite moving;
    [SerializeField] private float forceAmount = 10.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPhysics.AddForce(Vector2.left * forceAmount);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPhysics.AddForce(Vector2.right * forceAmount);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = moving;
            var emission = walkDust.emission;
            emission.enabled = true;
        }
        else
        {
            spriteRenderer.sprite = idle;
            var emission = walkDust.emission;
            emission.enabled = false;
        }
    }
}
