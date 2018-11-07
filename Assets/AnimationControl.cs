using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    public Animator anim;
    public bool showcase;

	// Use this for initialization
	void Start () {
        anim = this.gameObject.GetComponent<Animator>();
        if (showcase)
        {          
            anim.runtimeAnimatorController = Resources.Load("AnimatorMixamo") as RuntimeAnimatorController;
        }
        else
        {
            anim.runtimeAnimatorController = Resources.Load("AnimatorCommands") as RuntimeAnimatorController;
        }
    }
	
	// Update is called once per frame
	void Update () {       
        if (showcase)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Showcase");
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                showcase = false;
                anim.runtimeAnimatorController = Resources.Load("AnimatorCommands") as RuntimeAnimatorController;
            }
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            {
                if (this.transform.position.y < 0 || this.transform.position.y > 0.08)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetTrigger("Forward");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetTrigger("Backward");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetTrigger("DodgeL");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetTrigger("DodgeR");
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetTrigger("TurnAround");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                anim.SetTrigger("AttackChain1");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                anim.SetTrigger("AttackChain2");
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                anim.SetTrigger("AttackChain3");
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                showcase = true;
                anim.runtimeAnimatorController = Resources.Load("AnimatorMixamo") as RuntimeAnimatorController;
            }

        }

    }
}

