using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerPhysics;
    [SerializeField] private float forceAmount = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPhysics.AddForce(Vector2.left * forceAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPhysics.AddForce(Vector2.right * forceAmount);
        }


    }
}
