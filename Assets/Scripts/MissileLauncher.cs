// MissileLauncher.cs 
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Doğan Çakır | Student ID: 210444075

using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        // Clear the old missile if it exists (to prevent ghost missiles)
        DestroyActiveMissile();

        // Instantiate the missile at the launch point (Task 3-A)
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        // Tell the missile who to follow (Task 3-B)
        MissileHoming homingComponent = activeMissile.GetComponent<MissileHoming>();
        if (homingComponent != null)
        {
            homingComponent.SetTarget(target);
        }
        
        // Play launch audio (Task 3-C)
        if (launchAudioSource != null)
        {
            launchAudioSource.Play();
        }

        Debug.Log("Missile Launched!");
        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        // Destroy the current missile safely if one exists (Task 3-D)
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }

        // Stop the flying sound when the missile is destroyed!
        if (launchAudioSource != null)
        {
            launchAudioSource.Stop();
        }
    }
}