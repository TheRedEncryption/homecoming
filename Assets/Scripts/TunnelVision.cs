using UnityEngine;

public class TunnelVision : MonoBehaviour
{
    [SerializeField] 
    private GameObject tunnelVisionOverlay;

    private void Awake() 
    {
        if (tunnelVisionOverlay == null) 
        {
            tunnelVisionOverlay.SetActive(false);
        }
    }

    public void ActivateTunnelVision()
    {
        if (tunnelVisionOverlay == null)
        {
            Debug.LogError("Tunnel Vision Overlay is missing!");
            return;
        }

        tunnelVisionOverlay.SetActive (true);
        Debug.Log("Tunnel Vision Activated");
    }


}
