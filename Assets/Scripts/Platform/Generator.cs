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
    class Generator : MonoBehaviour
    {
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

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
            if(numSpawned<1)
            {
                //where your instantiated object spawns from
                transform.position = new Vector2(1,2);
                SpawnRandomSection();
            }
        }

    }
}

