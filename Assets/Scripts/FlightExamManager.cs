using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    
    public bool hasTakenOff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

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
        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }
    }

    public void ExitDangerZone()
    {
        if (statusText != null)
        {
            statusText.text = "Threat Escaped. Safe to Land.";
            statusText.color = Color.green;
        }
        
        threatCleared = true; 
    }
}