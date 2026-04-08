using UnityEngine;

public class ScavengeItem : MonoBehaviour
{
    public GameObject goldBurstVFX; // Drag your GoldBurst_VFX here

    public void OnInteract()
    {
        // 1. Spawn particles at the chest's location
        if (goldBurstVFX != null)
        {
            GameObject effect = Instantiate(goldBurstVFX, transform.position, Quaternion.identity);
            Destroy(effect, 2f); // Cleanup particles after 2 seconds
        }

        // 2. Update the count
        GameManager.instance.ItemCollected();

        // 3. The chest (and its internal fog volume) disappears
        Destroy(gameObject);
    }
}