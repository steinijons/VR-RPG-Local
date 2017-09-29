using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedingBehaviour : StateMachineBehaviour {

    [SerializeField]
    private string text;
    [SerializeField]
    private AudioClip voice;

    private string answer;

    public void recieveAnswer()
    {
        this.answer = EventDispatcher.Instance.CurrentAnswer;
    }

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        EventDispatcher.Instance.updateSound(voice);
        EventDispatcher.Instance.updateQuestion(text);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(animator.GetBool("AnswerRecieved"))
        {
            recieveAnswer();
            if (answer.Contains("Hello"))
            {
                animator.SetTrigger("GreetingToAskingForBooze");
            }
            else
            {
                animator.SetTrigger("GreetingToWaiting");
            }
            animator.SetBool("AnswerRecieved", false);
        }

        
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //    
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
