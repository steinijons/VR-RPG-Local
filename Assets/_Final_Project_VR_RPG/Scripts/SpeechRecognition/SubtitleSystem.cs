using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleSystem : MonoBehaviour {

	// Use this for initialization

	private string subtitle;
	bool displayText;

	Text text;
	void Start(){
	}
	void Awake (){
		text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(EventDispatcher.Instance.isTalking)
		{
			print(EventDispatcher.Instance.CurrentText);
		}
		//text.text = "NPC: " + subtitle;
	} 
}
