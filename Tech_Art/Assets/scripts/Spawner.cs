using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocation;
    [SerializeField] private GameObject[] spawnPrefab;

    private void Start()
    {
        SpawnRandomPrefab();
    }

    void SpawnRandomPrefab()
    {
        int prefabIndex = Random.Range(0, spawnPrefab.Length);
        int locationIndex = Random.Range(0, spawnLocation.Length);
        Vector3 spawnPosition = spawnLocation[locationIndex].position;
        Quaternion spawnRotation = Quaternion.identity;

        GameObject spawnedObject = Instantiate(spawnPrefab[prefabIndex], spawnPosition, spawnRotation);
    }

}