using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 4.0f; // Distance from which you can collect
    public GameObject interactUI;        // Drag your InteractPrompt here
    public LayerMask chestLayer;         // Set this to "Default" or a new "Chest" layer

    void Update()
    {
        // Shoot a ray from the center of the camera forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, chestLayer))
        {
            // If the ray hits something with the ScavengeItem script
            if (hit.collider.TryGetComponent(out ScavengeItem chest))
            {
                interactUI.SetActive(true); // Show the [E] prompt

                if (Input.GetKeyDown(KeyCode.E))
                {
                    chest.OnInteract();
                    interactUI.SetActive(false); // Hide prompt after collecting
                }
            }
        }
        else
        {
            interactUI.SetActive(false); // Hide prompt if not looking at a chest
        }
    }
}