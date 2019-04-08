using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private float speed;
        public float VerticalSpeed;
        public float HorizontalSpeed;
        public float jumpSpeed = 10.0F;
        public float gravity;
        public Vector3 forward;
        public Vector3 right;
        private Vector3 moveDirection = Vector3.zero;
        PlayerHealth stam;

        public GameObject stamObj;
    // Работает и это главное
    // Не трогать

    void Start()
        {
            controller = GetComponent<CharacterController>();
            stam = GetComponent<PlayerHealth>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && stam.currentStam > 0)
            {
                speed = 9f;
            stamObj.SetActive(true);
            }
            else
            {
                speed = 5f;
            stamObj.SetActive(false);
        }
            // Rotate around y - axis
            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            VerticalSpeed = speed * Input.GetAxis("Vertical");
            HorizontalSpeed = speed * Input.GetAxis("Horizontal");

            // Move forward / backward
            forward = transform.TransformDirection(Vector3.forward);
            right = transform.TransformDirection(Vector3.right);
            controller.SimpleMove(forward * VerticalSpeed);
            controller.SimpleMove(right * HorizontalSpeed);

            if (!controller.isGrounded) gravity -= 20f * Time.deltaTime;
            else gravity = -1f;

            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                gravity = jumpSpeed;
                controller.SimpleMove(forward * VerticalSpeed);
            }

            moveDirection.y = gravity;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }