using UnityEngine;

public class LandingAreaController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the landing object is the player
        if (other.CompareTag("Player"))
        {
            if (examManager != null)
            {
                examManager.CompleteMission();
            }
        }
    }
}