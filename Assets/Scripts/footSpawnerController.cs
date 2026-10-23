using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class footSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject footPrefab;
    [SerializeField] private GameObject shadowPrefab;
    [SerializeField] private Collider2D spawnArea;
    [SerializeField] private float minX = -10.5f;
    [SerializeField] private float maxX = 10.5f;

    private void Start()
    {
        StartCoroutine(spawningTime(60, (float)0.5));
    }

    IEnumerator spawningTime(float duration, float delay)
    {
        float time = 0f;

        while (time < duration)
        {
            if (time <= 30)
            {
                delay = 3;
            }
            else if (time <= 45)
            {
                delay = 2;
            }
            else if (time <= 55)
            {
                delay = 1;
            }
            float interval = 1.5f;
            float randomPosition = Mathf.Round(Random.Range(minX, maxX)) * interval;

            Vector3 spawnPosition = new(transform.position.x + randomPosition, transform.position.y, transform.position.z);
            Vector3 shadowSpawnPosition = new(spawnPosition.x, spawnPosition.y - 153.95f, spawnPosition.z - 1);

            GameObject footClone = Instantiate(footPrefab, spawnPosition, Quaternion.identity);
            GameObject shadowClone = Instantiate(shadowPrefab, shadowSpawnPosition, Quaternion.identity);

            footMovement footScript = footClone.GetComponent<footMovement>();
            shadowDestroy shadowScript = shadowClone.GetComponent<shadowDestroy>();

            footScript.mySpecificShadow = shadowScript;


            yield return new WaitForSeconds(delay);

            time += delay;
        }
    }
}