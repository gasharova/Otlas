using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;

    public Animator textDisplayAnim;

    IEnumerator Type()
    {
        textDisplay.text = ""; //clears placeholder text and previous sentence

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        //wait a while then fade out
        yield return new WaitForSeconds(1f);
        textDisplayAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        textDisplay.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    //Next sentence in dialogue
    public void NextSentence()
    {
        textDisplayAnim.SetTrigger("Change");
        //I'd like to check for some game variable to check story progress- maybe deaths/restarts/coins
        if (index < sentences.Length -1)
        {
            index++;
            StartCoroutine(Type());
        }
    }
}
