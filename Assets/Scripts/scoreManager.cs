using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class scoreManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private MMF_Player scoreCount;
    [SerializeField] private float minX = -10.5f;
    [SerializeField] private float maxX = 10.5f;
    private int score = 0;

    private void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        Debug.Log($"{score}");
    }

    public void DisplayScore()
    {
        MMF_TMPCountTo textFeedback = scoreCount.GetFeedbackOfType<MMF_TMPCountTo>();
        if (textFeedback != null)
        {
            textFeedback.CountFrom = 0f;
            textFeedback.CountTo = score;

            scoreCount.PlayFeedbacks();
        }
    }

    public IEnumerator spawnCoins(float duration, float delay)
    {
        float time = 0f;

        while (time < duration)
        {
            float interval = 1.5f;
            float randomPosition = Mathf.Round(Random.Range(minX, maxX)) * interval;

            Vector3 spawnPosition = new(transform.position.x + randomPosition, transform.position.y, transform.position.z);

            GameObject coinClone = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);


            yield return new WaitForSeconds(delay);

            time += delay;
        }
    }
}
