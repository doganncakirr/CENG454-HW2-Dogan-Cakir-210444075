using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        // Cache the aircraft transform (Task 3-E)
        target = newTarget;
    }

    void Update()
    {
        // If there is no target, don't do anything
        if (target == null) return;

        // Rotate toward the target and move forward (Task 3-F)
        Vector3 direction = (target.position - transform.position).normalized;
        
        // Calculate the rotation to look at the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        // Smoothly rotate the missile towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        
        // Move the missile forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}