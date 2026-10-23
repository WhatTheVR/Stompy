using UnityEngine;
using UnityEngine.Rendering.Universal;

public class playerDeath : MonoBehaviour
{
    public void KillPlayer()
     {
        Destroy(gameObject);
     }
}
