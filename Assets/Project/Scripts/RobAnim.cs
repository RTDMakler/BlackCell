using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RobAnim : MonoBehaviour
    
{
    Animator animator;
    bool flag;
    void Start()
    {
        animator = GetComponent<Animator>();
        flag = true;
    }

    void SetBoolTransition(string a, string b, string c, string d, string e, string f)
    {
        animator.SetBool(a, true);
        animator.SetBool(b, false);
        animator.SetBool(c, false);
        animator.SetBool(d, false);
        animator.SetBool(e, false);
        animator.SetBool(f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjObserve.isObseveItem)
        {
            flag = true;

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    SetBoolTransition("Run", "Walk", "WalkR", "WalkL", "Stay", "WalkBack");
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    SetBoolTransition("Walk", "WalkR", "WalkL", "Stay", "Run", "WalkBack");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    SetBoolTransition("WalkBack", "WalkL", "Walk", "WalkR", "Stay", "Run");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    SetBoolTransition("WalkR", "Walk", "WalkL", "Stay", "Run", "WalkBack");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    SetBoolTransition("WalkL", "Walk", "WalkR", "Stay", "Run", "WalkBack");
                }
                else
                {
                    SetBoolTransition("Stay", "Walk", "WalkL", "WalkR", "Run", "WalkBack");   
            }
        }
        else
        { 
            if(flag)
            {
                flag = false;
                SetBoolTransition("Stay", "Walk", "WalkL", "WalkR", "Run", "WalkBack");
            }
        }
       
    }
}
