using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour

{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressedKey = Input.GetKey(KeyCode.W);
        bool runPressedKey = Input.GetKey(KeyCode.LeftShift);
        if (!isWalking && forwardPressedKey)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressedKey)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isrunning && (forwardPressedKey && runPressedKey))
        {
            animator.SetBool(isRunningHash, true);

        }
        if (isrunning && (!forwardPressedKey || !runPressedKey))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
    
}

