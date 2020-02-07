using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float TimeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfenemies = 5;
    [SerializeField] float movespeed = 3f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns()
    {
        return TimeBetweenSpawns;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public float GetMoveSpeed()
    {
        return movespeed;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfenemies;
    }


}
