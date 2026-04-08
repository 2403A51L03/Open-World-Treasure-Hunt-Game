using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RadarSystem : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public Transform playerTransform; // Drag your First Person Controller here

    void Update()
    {
        FindNearestItem();
    }

    void FindNearestItem()
    {
        ScavengeItem[] items = FindObjectsOfType<ScavengeItem>();

        if (items.Length == 0)
        {
            distanceText.text = "The treasure is ours!";
            return;
        }

        float closestDistance = Mathf.Infinity;
        foreach (ScavengeItem item in items)
        {
            float distance = Vector3.Distance(playerTransform.position, item.transform.position);
            if (distance < closestDistance) closestDistance = distance;
        }

        // A more thematic way to display distance for a pirate game
        if (closestDistance < 5f)
            distanceText.text = "Collect the tresure!";
        else
            distanceText.text = $"Treasure is {closestDistance:F0} steps away!";
    }
}