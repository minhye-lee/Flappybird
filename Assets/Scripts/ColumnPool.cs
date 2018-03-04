using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public GameObject columnPrefab;
    public int columnPoolSize = 5;

    public float spawnRate = 3f;

    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2(-10, -25);

    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0;

        columns = new GameObject[5];

        for(int i = 0; i < columns.Length; i++)
        {
            columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);

        }
    }

    void Update()
    {
        timeSinceLastSpawned = timeSinceLastSpawned + Time.deltaTime;
        
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
   
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
