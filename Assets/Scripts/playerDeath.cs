using MoreMountains.Feedbacks;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    [SerializeField] private MMF_Player screenShake;
    public void KillPlayer()
     {
        screenShake.PlayFeedbacks();
        Destroy(gameObject);
     }
}
