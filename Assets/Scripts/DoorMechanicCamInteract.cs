using UnityEngine;

public class DoorMechanicCamInteract : MonoBehaviour
{
    public bool CanInteract = true;

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }

    }

    private void CheckInteraction()
    {
        Ray doorray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(doorray, out hit, 5f))
        {
            if (hit.collider.CompareTag("Door"))
            {
                if(hit.collider.gameObject.GetComponent<SimpleDoor>() != null)
                {
                    hit.collider.gameObject.GetComponent<SimpleDoor>().ToggleDoorState();
                }
            }
        }
    }
}
