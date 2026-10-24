using UnityEngine;

public class backgroundController : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            float direction = -horizontalInput;
            float newX = transform.position.x + (scrollSpeed * Time.deltaTime * direction);
            transform.position = new Vector2(newX, transform.position.y);
        }
    }
}
