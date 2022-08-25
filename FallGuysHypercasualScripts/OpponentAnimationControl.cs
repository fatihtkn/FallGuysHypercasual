using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAnimationControl : MonoBehaviour
{
    private Animator animator;
    public static OpponentAnimationControl girlAnimatorSc;
    public bool control;
    private StartMenu startMenu;
    private List<string> animationNames;

    private void Start()
    {
        animationNames = new List<string>();
        animationNames.Add("Rumba");
        animationNames.Add("Drunk");
        animationNames.Add("Spin");
        animationNames.Add("HipHop");
        animationNames.Add("Silly");




        animator = GetComponent<Animator>();
        girlAnimatorSc = GetComponent<OpponentAnimationControl>();
        startMenu = GameObject.FindGameObjectWithTag("UIManager").GetComponent<StartMenu>();
        //animator.SetTrigger("runTrigger");

        SelectIdleAnimation(Random.Range(0,4));
    }
    private void Update()
    {
        if (startMenu.control)
        {
            animator.SetTrigger("runTrigger");


        }
    }
    private void SelectIdleAnimation(int a)
    {
        animator.Play(animationNames[a]);
    }
}
