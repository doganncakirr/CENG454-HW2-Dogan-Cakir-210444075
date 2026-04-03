using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; // Reference to the launcher
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private Transform playerTransform; // Cached reference to the player's transform

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
            playerTransform = other.transform; // Cache the player as the target
            
            // Start the delayed missile launch countdown
            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.ExitDangerZone();
            
            // Cancel any pending launch countdown if the player exits early
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
            
            // Destroy the active missile and clear the HUD warning
            missileLauncher.DestroyActiveMissile();
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        
        // 5 seconds passed! Launch the missile and pass the player as the target
        missileLauncher.Launch(playerTransform);
        activeCountdown = null;
    }
}