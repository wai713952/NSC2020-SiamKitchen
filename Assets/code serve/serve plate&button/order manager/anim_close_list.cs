using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_close_list : StateMachineBehaviour    //list self-destroy after serve
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Destroy(animator.gameObject, stateInfo.length);  //destroy this object after animation end (animation is play in other script)
    }
}