using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float timer = 1f;
    int point;

    private void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while(true)
        {
            point = Random.Range(0, spawnPoints.Length);
            GameObject spawnedEnemy = Instantiate(enemy);
            spawnedEnemy.transform.position = spawnPoints[point].position;
            yield return new WaitForSeconds(timer);
        }
    }
}
