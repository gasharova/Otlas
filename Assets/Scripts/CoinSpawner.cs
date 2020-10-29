using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject Player;
    public GameObject SpawnPoint;



    private float timeBtwSpawn; //Keeps changing, countdown
    public float startTimeBtwSpawn; //Initial spike cooldown
    public float decreaseTime; //Amount of time to decrease the countdown by
    public float minTime = 0.65f; //The minimum time between spikes
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
            //Randomise y between -3.8 and 4
            int coinY = rnd.Next(-3, 4);
            Vector3 newSpikePos = new Vector3(transform.position.x + distance, coinY, transform.position.z);

            //Instantiate(obstacle, newSpikePos, Quaternion.identity); //Spawn obstacle at spawner at current spawner position with no rotation
            GameObject MyClone = (GameObject)GameObject.Instantiate(obstacle, newSpikePos, Quaternion.identity);

            //Add some degree of randomness to the timer
            randomAmount = (float)rnd.NextDouble();
            timeBtwSpawn = startTimeBtwSpawn + randomAmount*2; //Reset spawning timer


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
