using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    
    public bool hasTakenOff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;
    public bool isDestroyed = false; // To track if the player was hit

    void Start()
    {
        if (statusText != null)
        {
            statusText.text = "System Online: Proceed to Corridor";
            statusText.color = Color.white;
        }
    }

    public void EnterDangerZone()
    {
        isDestroyed = false; // Reset the state when re-entering
        
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }
    }

    public void ExitDangerZone()
    {
        // If the player exited because they were destroyed and teleported, do not overwrite the text!
        if (isDestroyed) return;

        if (statusText != null)
        {
            statusText.text = "Threat Escaped. Safe to Land.";
            statusText.color = Color.green;
        }
        threatCleared = true; 
    }

    public void AircraftHit()
    {
        isDestroyed = true; // Mark as destroyed
        threatCleared = false; // The threat was not successfully cleared

        if (statusText != null)
        {
            statusText.text = "Aircraft Hit! Mission Failed.";
            statusText.color = Color.red;
        }
        missionComplete = false;
    }

    public void CompleteMission()
    {
        // Do nothing if the mission is already complete or the aircraft is destroyed
        if (missionComplete || isDestroyed) return;

        // Landing validation: Has the threat been cleared? (Task 4.2)
        if (threatCleared)
        {
            if (statusText != null)
            {
                statusText.text = "Mission Complete! Excellent flying.";
                statusText.color = Color.blue;
            }
            missionComplete = true;
        }
        else
        {
            // Warn the player if they try to land without entering the danger zone
            if (statusText != null)
            {
                statusText.text = "Cannot land yet! You must enter and clear the Threat Zone.";
                statusText.color = Color.yellow;
            }
        }
    }
}