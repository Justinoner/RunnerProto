using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSpawnData", menuName = "ScriptableObjects/NewObstacleSpawn", order = 1)]
public class NewObstacleSpawn : ScriptableObject
{
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}