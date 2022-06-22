using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject nagent;
    public GameObject target;
    public enum spawnState { SPAWNING, WAITING, COUNTING}
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;

    private int nextWave = 0;
    private float timeBetweenWaves = 5f;
    public float waveCountdown;
    public spawnState state = spawnState.COUNTING;
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }
    void FixedUpdate()
    {
        if (waveCountdown <= 0)
        {
            state = spawnState.SPAWNING;
            if (state != spawnState.COUNTING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                nextWave++;
                waveCountdown = timeBetweenWaves;
            }                
        }
        else
            waveCountdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = spawnState.SPAWNING;
        Debug.Log("SPAWNING WAVE");
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnAgent(_wave.enemy);            
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = spawnState.WAITING;
        yield break;
    }

    void SpawnAgent (GameObject _enemy)
    {
        GameObject na = (GameObject)Instantiate(_enemy, transform.position, Quaternion.identity);
        na.GetComponent<WalkTo>().goal = target.transform;
        Debug.Log("SPAWNING");
    }
}
