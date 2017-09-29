using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDispatcher : MonoBehaviour {

    public string CurrentText { get; private set; }
    public string CurrentAnswer { get; private set; }
    public AudioClip CurrentAudio { get; private set; }

    public bool isTalking {get; private set;}
    
    private static EventDispatcher instance;

    public static EventDispatcher Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void updateQuestion(string newText)
    {
        print("updating to " + newText);
        CurrentText = newText;
    }

    public void updateAnswer(string newText, Animator ani)
    {
        print("Answer Recieved " + newText);
        CurrentAnswer = newText;
        ani.SetBool("AnswerRecieved", true);
    }

    public void updateSound(AudioClip voice)
    {
        CurrentAudio = voice;
    }

    public void isPlayerTalkingToPlayer(bool d){
        isTalking = d;
    }
}
