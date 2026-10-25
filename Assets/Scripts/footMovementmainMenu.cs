using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class footMovementMainMenu : MonoBehaviour
{
    [SerializeField] private float forceAmount;
    [SerializeField] private playerDeath playerDeath;
    [SerializeField] private shadowDestroy shadowDestroy;
    [SerializeField] private footSpawnerController footSpawner;
    [SerializeField] private footSpawnerControllerEndless footSpawner2;
    [SerializeField] private Collider2D deathZone;
    [SerializeField] private MMF_Player cameraShake;
    [SerializeField] private AudioSource fallingOne;
    [SerializeField] private AudioSource fallingTwo;
    [SerializeField] private AudioSource deathSound;
    private bool isEndlessMode;

    private Rigidbody2D footPhysics;

    [HideInInspector] public shadowDestroy mySpecificShadow;





    private void Awake()
    {
        footPhysics = GetComponent<Rigidbody2D>();
        playerDeath = FindAnyObjectByType<playerDeath>();
        footSpawner = FindAnyObjectByType<footSpawnerController>();
        footSpawner2 = FindAnyObjectByType<footSpawnerControllerEndless>();

        if (footSpawner2 != null)
        {
            isEndlessMode = true;
        }
        else if (footSpawner != null)
        {
            isEndlessMode = false;
        }

        if (Random.value > 0.5f)
        {
            fallingOne.Play();
        }
        else
        {
            fallingTwo.Play();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            fallingOne.Stop();
            fallingTwo.Stop();
            cameraShake.PlayFeedbacks();
            deathZone.enabled = false;
            StartCoroutine(MoveFootUp(6));
        }
        else if (other.CompareTag("Player"))
        {
            fallingOne.Stop();
            fallingTwo.Stop();
            playerDeath.KillPlayer();
            deathSound.Play();
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
