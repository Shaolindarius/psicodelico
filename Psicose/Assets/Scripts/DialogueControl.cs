using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text SpeechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;


    public void Speech(Sprite p, string txt , string ActorsName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        SpeechText.text = txt;
        actorNameText.text = ActorsName;

    }
}
