using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogController : MonoBehaviour {

    protected AudioClip audioClip;
    protected AudioSource audioSrc;
    protected Animator fsm;
    protected VoiceToText voiceToText;

    // Use this for initialization
    void Awake() {
        voiceToText = GetComponent<VoiceToText>();
        if(voiceToText == null) {
            print("voicetotext not found");
        }
        fsm = GetComponentInParent<Animator>();
        if (fsm == null)
            print("Animator not found in dialog!");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    protected virtual void updateAnswer(string answer) {
        EventDispatcher.Instance.updateAnswer(answer, fsm);
    }

    protected virtual void isPlayerTalkingToNPC(bool d){
        EventDispatcher.Instance.isPlayerTalkingToPlayer(d);
    }

}
