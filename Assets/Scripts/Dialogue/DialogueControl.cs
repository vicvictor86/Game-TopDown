using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")] 
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")] 
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] senteces;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in senteces[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentece()
    {
        
    }

    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            senteces = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
