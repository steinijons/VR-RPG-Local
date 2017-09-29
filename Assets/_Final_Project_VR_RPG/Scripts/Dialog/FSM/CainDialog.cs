using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CainDialog : NPCDialogController {
    

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)) {
            voiceToText.startSpeaking();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            updateAnswer(voiceToText.doneSpeaking());
        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            print("Triggerd");
            isPlayerTalkingToNPC(true);
            fsm.SetTrigger("Arrived");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            print("Out of trigger");
            isPlayerTalkingToNPC(false);
            fsm.SetTrigger("Left");
        }
    }
}
