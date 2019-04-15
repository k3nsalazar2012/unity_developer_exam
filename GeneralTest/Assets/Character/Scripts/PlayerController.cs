using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private CharacterController controller;
        
        void Update()
        {
            Movement();           
        }

        private void Movement()
        {
            if (Input.GetKeyDown(KeyCode.W))
                animator.SetInteger("vertical", 1);
            else if (Input.GetKeyDown(KeyCode.S))
                animator.SetInteger("vertical", -1);
            else if (Input.GetKeyDown(KeyCode.D))
                animator.SetInteger("horizontal", 1);
            else if (Input.GetKeyDown(KeyCode.A))
                animator.SetInteger("horizontal", -1);
            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                animator.SetFloat("Blend", 1f);

            if (Input.GetKeyUp(KeyCode.W))
                animator.SetInteger("vertical", 0);
            else if (Input.GetKeyUp(KeyCode.S))
                animator.SetInteger("vertical", 0);
            else if (Input.GetKeyUp(KeyCode.D))
                animator.SetInteger("horizontal", 0);
            else if (Input.GetKeyUp(KeyCode.A))
                animator.SetInteger("horizontal", 0);
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
                animator.SetFloat("Blend", 0f);
        }
    }
}