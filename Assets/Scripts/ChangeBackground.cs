using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    private string currentBackground;

    //All of our different backgrounds
    public GameObject darkForest;
    public GameObject rockyHills;
    public GameObject peacefulMountains;
    public GameObject waterfalls;

    public Animator FadeOut;
    public Animator FadeIn;

    public bool musicIsOff = true;
    IEnumerator DialogCoroutine()
    {

        GameObject D = GameObject.Find("DialogueManager");
        Dialog dialogScript = D.GetComponent<Dialog>();
        dialogScript.NextSentence();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        dialogScript.NextSentence();

        yield return new WaitForSeconds(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set starting background
        currentBackground = "darkForest";
        // Music for the specific background
        BackgroundAudio.PlaySound("DarkForest");
         //   musicIsOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Initial background music
        if (musicIsOff)
        {
            //BackgroundAudio.PlaySound("MainTheme");
            //musicIsOff = false;
        }

        //Change backgrounds according to coin number
        GameObject thePlayer = GameObject.Find("Player");
        CoinCollision coinScript = thePlayer.GetComponent<CoinCollision>();
        int coinNum = (int)coinScript.coin; //Get number of coins from the coin script

        //Check number of coins
        if (coinNum == 10)
        {

            //Change to rockyHills
            if (currentBackground != "rockyHills")
            {
                currentBackground = "rockyHills";

                //Animate
                //out with current background
                FadeOut = darkForest.GetComponent<Animator>();
                FadeOut.SetTrigger("FadeOut");
                //in with new background
                FadeIn = rockyHills.GetComponent<Animator>();
                FadeIn.SetTrigger("FadeIn");

                //Reset all backgrounds away 
                /*
                darkForest.transform.position = new Vector3(darkForest.transform.position.x, -100, darkForest.transform.position.z);
                peacefulMountains.transform.position = new Vector3(peacefulMountains.transform.position.x, -100, peacefulMountains.transform.position.z);
                rockyHills.transform.position = new Vector3(rockyHills.transform.position.x, -100, rockyHills.transform.position.z);
                waterfalls.transform.position = new Vector3(waterfalls.transform.position.x, -100, waterfalls.transform.position.z);
                */
                //Move the one we want
                rockyHills.transform.position = new Vector3(rockyHills.transform.position.x, -1, rockyHills.transform.position.z);
                
                // Music for the specific background
                BackgroundAudio.PlaySound("RockyHills");

                //Change dialogue
                GameObject D = GameObject.Find("DialogueManager");
                Dialog dialogScript = D.GetComponent<Dialog>();
                StartCoroutine(DialogCoroutine());
            }
        }
        else if (coinNum == 20)
        {
            //Change to peacefulMountains
            if (currentBackground != "peacefulMountains")
            {
                //Animate
                //out with current background
                FadeOut = rockyHills.GetComponent<Animator>();
                FadeOut.SetTrigger("FadeOut");
                //in with new background
                FadeIn = peacefulMountains.GetComponent<Animator>();
                FadeIn.SetTrigger("FadeIn");

                currentBackground = "peacefulMountains";
                //Reset all backgrounds away
                /*
                darkForest.transform.position = new Vector3(darkForest.transform.position.x, -100, darkForest.transform.position.z);
                peacefulMountains.transform.position = new Vector3(peacefulMountains.transform.position.x, -100, peacefulMountains.transform.position.z);
                rockyHills.transform.position = new Vector3(rockyHills.transform.position.x, -100, rockyHills.transform.position.z);
                waterfalls.transform.position = new Vector3(waterfalls.transform.position.x, -100, waterfalls.transform.position.z);
                */
                //load new
                FadeIn = peacefulMountains.GetComponent<Animator>();
                FadeIn.SetTrigger("FadeIn");
                //Move the one we want
                peacefulMountains.transform.position = new Vector3(peacefulMountains.transform.position.x, -1, peacefulMountains.transform.position.z);

                // Music for the specific background
                BackgroundAudio.PlaySound("PeacefulMountains");

                //Change dialogue
                GameObject D = GameObject.Find("DialogueManager");
                Dialog dialogScript = D.GetComponent<Dialog>();
                StartCoroutine(DialogCoroutine());
            }
        }
        else if (coinNum == 35)
        {
            //Change to waterfalls
            if (currentBackground != "waterfalls")
            {
                //Animate
                //out with current background
                FadeOut = peacefulMountains.GetComponent<Animator>();
                FadeOut.SetTrigger("FadeOut");
                //in with new background
                FadeIn = waterfalls.GetComponent<Animator>();
                FadeIn.SetTrigger("FadeIn");

                currentBackground = "waterfalls";
                //Reset all backgrounds away
                /*
                darkForest.transform.position = new Vector3(darkForest.transform.position.x, -100, darkForest.transform.position.z);
                peacefulMountains.transform.position = new Vector3(peacefulMountains.transform.position.x, -100, peacefulMountains.transform.position.z);
                rockyHills.transform.position = new Vector3(rockyHills.transform.position.x, -100, rockyHills.transform.position.z);
                waterfalls.transform.position = new Vector3(waterfalls.transform.position.x, -100, waterfalls.transform.position.z);
                */
                //Move the one we want
                waterfalls.transform.position = new Vector3(waterfalls.transform.position.x, -1, waterfalls.transform.position.z);

                // Music for the specific background
                BackgroundAudio.PlaySound("Waterfalls");

                //Change dialogue
                GameObject D = GameObject.Find("DialogueManager");
                Dialog dialogScript = D.GetComponent<Dialog>();
                dialogScript.NextSentence();
            }
        }

    }
}
