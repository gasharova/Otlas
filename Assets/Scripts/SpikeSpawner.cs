using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject Player;
    public GameObject SpawnPoint;


    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    private float randomAmount;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            //Check how far the player has moved from the spawn point
            float distance = Vector2.Distance(Player.transform.position, SpawnPoint.transform.position);
            Vector3 newSpikePos = new Vector3(transform.position.x+distance, transform.position.y, transform.position.z);
            Instantiate(obstacle, newSpikePos, Quaternion.identity); //Spawn obstacle at spawner at current spawner position with no rotation
            //Add some degree of randomness
            
            randomAmount = (float) rnd.NextDouble();
            timeBtwSpawn = startTimeBtwSpawn + randomAmount; //Reset spawning timer

            //As long as the time between spawn does not fall below minimum, decrease to make game harder
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        
    }
}
