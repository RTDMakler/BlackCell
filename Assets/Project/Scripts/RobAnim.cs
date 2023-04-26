using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RobAnim : MonoBehaviour
    
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void SetBoolTransition(string a, string b, string c, string d, string e)
    {
        animator.SetBool(a, true);
        animator.SetBool(b, false);
        animator.SetBool(c, false);
        animator.SetBool(d, false);
        animator.SetBool(e, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjObserve.isObseveItem)
        {
            animator.SetBool("isPause", false);
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                SetBoolTransition("Run", "Walk", "WalkR", "WalkL", "Stay");
            }
            else if (Input.GetKey(KeyCode.W))
            {
                SetBoolTransition("Walk", "WalkR", "WalkL", "Stay", "Run");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetBoolTransition("WalkR", "Walk", "WalkL", "Stay", "Run");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SetBoolTransition("WalkL", "Walk", "WalkR", "Stay", "Run");
            }
            else
            {
                SetBoolTransition("Stay", "Walk", "WalkL", "WalkR", "Run");
            }
        }
        else
        {
            animator.SetBool("isPause", true);
        }
       
    }
}
