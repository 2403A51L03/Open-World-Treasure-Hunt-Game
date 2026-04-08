
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject chestPrefab;
    public GameObject fogPrefab;
    public int totalChests = 10;

    public float minX = -1500f, maxX = 1500f;
    public float minZ = -1500f, maxZ = 1500f;

    void Start()
    {
        SpawnAllChests();

        // Calculate time: Total Distance / Average Speed + Buffer
        float totalDist = 0;
        GameObject[] chests = GameObject.FindGameObjectsWithTag("Chest");

        foreach (GameObject chest in chests)
        {
            totalDist += Vector3.Distance(transform.position, chest.transform.position);
        }

        // Formula: (Average distance per chest / speed) * multiplier
        float calculatedTime = (totalDist / totalChests) * 1.5f + 30f;

        GameManager.instance.SetTotalChests(totalChests, calculatedTime);
    }

    void SpawnAllChests()
    {
        for (int i = 0; i < totalChests; i++)
        {
            float rX = Random.Range(minX, maxX);
            float rZ = Random.Range(minZ, maxZ);

            RaycastHit hit;
            if (Physics.Raycast(new Vector3(rX, 500f, rZ), Vector3.down, out hit, 1000f))
            {
                Vector3 spawnPos = hit.point + new Vector3(0, 0.2f, 0);
                GameObject chest = Instantiate(chestPrefab, spawnPos, Quaternion.identity);
                chest.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            }
        }
    }
}