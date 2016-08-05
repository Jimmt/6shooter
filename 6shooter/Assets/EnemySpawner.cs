using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float spawnInterval;
    public GameObject enemyPrefab;
    public Transform leftSpawnLimit, rightSpawnLimit;
    public ArrayList enemyList;
    float lastSpawnTime;

    // Use this for initialization
    void Start() {
        enemyList = new ArrayList();
        lastSpawnTime = -spawnInterval;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - lastSpawnTime >= spawnInterval) {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(leftSpawnLimit.position.x, rightSpawnLimit.position.x);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0,0,0)) as GameObject;
            lastSpawnTime = Time.time;
            enemyList.Add(enemy);
        }
    }
}
