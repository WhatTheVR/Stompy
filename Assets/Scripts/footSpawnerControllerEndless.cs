using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class footSpawnerControllerEndless : MonoBehaviour
{
    [SerializeField] private GameObject footPrefab;
    [SerializeField] private GameObject shadowPrefab;
    [SerializeField] private Collider2D spawnArea;
    [SerializeField] private SpriteRenderer footSprite;
    [SerializeField] private AudioSource aliveMusic;
    [SerializeField] private AudioSource deadMusic;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private scoreManager scoreManager;

    [SerializeField] private float minX = -10.5f;
    [SerializeField] private float maxX = 10.5f;


    private void Start()
    {
        StartCoroutine(spawningTime((float)1.5));
        StartCoroutine(scoreManager.spawnCoins(60, 6));
        aliveMusic.Play();
    }

    public void stopSpawning()
    {
        StopAllCoroutines();
        aliveMusic.Stop();
        StartCoroutine(Wait(4));
    }

    IEnumerator spawningTime(float delay)
    {
        float time = 0f;

        while (true)
        {
            float interval = 1.5f;
            float randomPosition = Mathf.Round(Random.Range(minX, maxX)) * interval;

            Vector3 spawnPosition = new(transform.position.x + randomPosition, transform.position.y, transform.position.z);
            Vector3 shadowSpawnPosition = new(spawnPosition.x, spawnPosition.y - 153.95f, spawnPosition.z - 1);

            GameObject footClone = Instantiate(footPrefab, spawnPosition, Quaternion.identity);

            GameObject shadowClone = Instantiate(shadowPrefab, shadowSpawnPosition, Quaternion.identity);

            if (Random.value > 0.5f)
            {
                footSprite.flipX = true;
            }
            else
            {
                footSprite.flipX = false;
            }

            footMovement footScript = footClone.GetComponent<footMovement>();
            shadowDestroy shadowScript = shadowClone.GetComponent<shadowDestroy>();

            footScript.mySpecificShadow = shadowScript;


            yield return new WaitForSeconds(delay);

            time += delay;
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        deathScreen.SetActive(true);
        scoreManager.DisplayScore();
        deadMusic.Play();
    }
}