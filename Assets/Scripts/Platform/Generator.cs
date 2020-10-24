using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class generates new sections.
    /// </summary> 
    /// 

    class Generator : MonoBehaviour
    {
        //Get player and spawnpoint positions to calculate how far the player has moved in the game, to determine where to place obstacles
        public GameObject Player;
        public GameObject SpawnPoint;

        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public float startTimeBtwSpawn;
        private float timeBtwSpawn; //How long between each spawn

        //define an Array
        public static GameObject[] sections;
        //I used this to keep track of the number of objects I spawned in the scene.
        public static int numSpawned = 0;
        public int numOfSections = 0;

        void Start()
        {
            //Important note: place your prefabs folder(or levels or whatever) 
            //in a folder called "Resources" like this "Assets/Resources/Sections"
            sections = Resources.LoadAll<GameObject>("Sections");
            numOfSections = sections.Length;
        }

        void SpawnRandomSection()
        {
            //spawns item in array position between 0 and 100
            int whichItemIndex = Random.Range(0, numOfSections-1);

            GameObject myObj = Instantiate(sections[whichItemIndex]) as GameObject;

            numSpawned++;

            myObj.transform.position = transform.position;
        }
        void Update()
        {
            if(timeBtwSpawn <= 0) //If the spawning timer ran out aka it is time to spawn new
            {
                //Calculate where the new object should spawn
                //Check how far the player has moved from the spawn point
                float distance = Vector2.Distance(Player.transform.position, SpawnPoint.transform.position);
                Vector3 newPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z); //Will need to change y to randomise


                //where your instantiated object spawns from
                transform.position = newPos;
                SpawnRandomSection();
                timeBtwSpawn = startTimeBtwSpawn; //Reset spawning timer
            }
            else //Decrease timer
            {
                timeBtwSpawn -= Time.deltaTime;
            }

        }

    }
}

