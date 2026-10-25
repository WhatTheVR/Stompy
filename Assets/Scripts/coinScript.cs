using MoreMountains.Feedbacks;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coinScript : MonoBehaviour
{
    [SerializeField] private MMF_Player coinSound;
    [SerializeField] scoreManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        manager = FindAnyObjectByType<scoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.AddScore();
            coinSound.PlayFeedbacks();
            Destroy(gameObject);
        }
    }
}
