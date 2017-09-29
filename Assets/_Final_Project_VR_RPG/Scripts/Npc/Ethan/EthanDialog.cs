using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanDialog : MonoBehaviour {

    public string[] answerButton;
    public string[] Questions;
    bool DisplayDialog = false;
    bool ActivateQuest = false;
    AudioSource audioSource;

    Animator fsm;

	// Use this for initialization
	void Start () {
        fsm = GetComponentInParent<Animator>();
        if (fsm == null)
            print("Animator not found in ethan dialog!");
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 400, 400));
        if (DisplayDialog && !ActivateQuest)
        {
            GUILayout.Label(EventDispatcher.Instance.CurrentText);
            //GUILayout.Label(Questions[1]);
            if(Input.GetKeyDown(KeyCode.Alpha1) ||GUILayout.Button(answerButton[0]))
            {
                EventDispatcher.Instance.updateAnswer("Hello", fsm);
                
                DisplayDialog = false;
                ActivateQuest = true;                
            }
            if(Input.GetKeyDown(KeyCode.Alpha2) || GUILayout.Button(answerButton[1]))
            {
                EventDispatcher.Instance.updateAnswer("don't like you", fsm);
                DisplayDialog = false;
            }
        }
        if(DisplayDialog && ActivateQuest)
        {
            GUILayout.Label(EventDispatcher.Instance.CurrentText);
            if(Input.GetKeyDown(KeyCode.Alpha1) || GUILayout.Button(answerButton[0]))
            {
                DisplayDialog = false;
            }
        }
        GUILayout.EndArea();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayDialog = true;
            //print("Triggerd");
            fsm.SetBool("Arrived", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayDialog = false;
           // print("Out of trigger");
            fsm.SetBool("Arrived", false);
        }
    }
}
