using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f; // 5 second rule

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        // Is the object that entered our plane?
        if (other.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
            
            // Start the 5-second missile timer.
            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.ExitDangerZone();
            
            // If the player exits before the 5 seconds are up, cancel the timer
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
                Debug.Log("Countdown Cancelled! Player escaped early.");
            }
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("5 seconds passed! Missile Launched! (We will add the actual missile in Task 3)");
    }
}