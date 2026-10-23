using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class footMovement : MonoBehaviour
{
    [SerializeField] private float forceAmount;
    [SerializeField] private playerDeath playerDeath;
    [SerializeField] private shadowDestroy shadowDestroy;
    [SerializeField] private Collider2D deathZone;
    private Rigidbody2D footPhysics;

    [HideInInspector] public shadowDestroy mySpecificShadow;





    private void Awake()
    {
        footPhysics = GetComponent<Rigidbody2D>();
        playerDeath = FindAnyObjectByType<playerDeath>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            mySpecificShadow.destroyShadow();
            deathZone.enabled = false;
            StartCoroutine(MoveFootUp(3));
        }
        else if (other.CompareTag("Player"))
        {
            playerDeath.KillPlayer();
        }
    }

    IEnumerator MoveFootUp(float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            footPhysics.AddForce(Vector2.up * forceAmount);

            yield return null;

            time += Time.deltaTime;
        }
        Destroy(gameObject);
    }

    
}
