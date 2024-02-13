using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject soldierPrefab; // Reference to the soldier prefab to spawn
    public Transform spawnPoint; // Point where the soldier will spawn

    void Start(){
        Debug.Log("Soldier Spawner started");
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space)) // Check if Space key is pressed
        {
            SpawnSoldier(); // Call the SpawnSoldier method
        }
    }

    void SpawnSoldier()
    {
        // Check if soldierPrefab is assigned and spawnPoint is assigned
        if (soldierPrefab != null && spawnPoint != null)
        {
            Instantiate(soldierPrefab, spawnPoint.position, Quaternion.identity); // Instantiate soldierPrefab at spawnPoint position with no rotation
        }
        else
        {
            Debug.LogError("Soldier prefab or spawn point is not assigned!"); // Log an error if soldierPrefab or spawnPoint is not assigned
        }
    }
}