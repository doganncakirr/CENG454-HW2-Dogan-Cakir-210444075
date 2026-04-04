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
}