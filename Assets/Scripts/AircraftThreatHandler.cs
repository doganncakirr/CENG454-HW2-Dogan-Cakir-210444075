using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint; 
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; // Ses ve füze temizliği için fırlatıcıyı buraya da ekledik

    private Rigidbody rb;

    void Start()
    {
        // Cache GetComponent<Rigidbody>() into 'rb' (Task 3-G)
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the missile hits the aircraft, apply the chosen penalty (Task 3-H)
        if (other.CompareTag("Missile"))
        {
            // Play the explosion sound
            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
            }

            // Update the UI and mark the mission as failed (Task 3-J, 3-K)
            if (examManager != null)
            {
                examManager.AircraftHit();
            }

            // Call the launcher to destroy the missile AND stop the flying sound
            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
            else
            {
                Destroy(other.gameObject); // Fallback
            }

            // As a penalty, we teleport the aircraft back to the runway
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
                
                // Reset velocity
                if (rb != null) rb.linearVelocity = Vector3.zero; 
            }
        }
    }
}