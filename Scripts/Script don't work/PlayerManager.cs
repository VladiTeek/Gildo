//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace PlayeManagers
//{
//    public class PlayerManager : MonoBehaviour
//    {
//        [Header("Player Settings")]

//        [Range(0f, 100f)]
//        [Tooltip("Character movement speed in the game")]
//        public float moveSpeed = 5f;

//        [Range(0f, 100f)]
//        [Tooltip("Character run speed in the game")]
//        public float runSpeed = 2f;

//        [Range(0f, 100f)]
//        [Tooltip("Character rotation speed in the game")]
//        public float turnSpeed = 100f;

//        [Range(0f, 200f)]
//        [Tooltip("Character jump forces in the game")]
//        public float jump = 10f;

//        public CharacterController controller;

//        public float speedH = 2f;
//        public float speedV = 2f;

//        private float yaw = 0.0f;
//        private float pitch = 0.0f;

//        PlayerHealth stam;

//        [Header("Resourses")]
//        public static int wood = 300;
//        public static int rock = 300;

//        void Start()
//        {
//            controller = GetComponent<CharacterController>();
//            stam = GetComponent<PlayerHealth>();
//        }

//        void Update()
//        {
//            yaw += speedH * Input.GetAxis("Mouse X");
//            pitch -= speedV * Input.GetAxis("Mouse Y");

//            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

//            if(Input.GetKey(KeyCode.W))
//            {
//                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
//            }
//            if(Input.GetKey(KeyCode.LeftShift))
//            {
//                RunPlayer();
//            }
//            if (Input.GetKey(KeyCode.S))
//            {
//                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
//            }
//            if(Input.GetKey(KeyCode.A))
//            {
//                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
//            }
//            if (Input.GetKey(KeyCode.D))
//            {
//                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
//            }

//        }


//        void RunPlayer()
//        {
//            if (stam.currentStam > 0)
//            {
//                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
//            }
            
//        }

//    }
//}