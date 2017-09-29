using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceToText : MonoBehaviour {

    DictationRecognizer dictationRecognizer;
    string word;

    private void Awake() {
        dictationRecognizer = new DictationRecognizer();
    }

    public void startSpeaking() {
        print("speak to text working");
        word = "";
        dictationRecognizer.DictationResult += onDictationResult;
        dictationRecognizer.Start();
    }   
    
    public string doneSpeaking() {
        print("Done speaking");
        dictationRecognizer.Stop();
        return word;
    }

    void onDictationResult(string text, ConfidenceLevel confidence) {
        word += text;
        Debug.LogFormat("Dictation result: " + text);
    } 
}