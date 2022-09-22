using System.Collections.Specialized;
using System.Numerics;
using System;

using TunnelRush.LevelGenarator;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace TunnelRush.Controller
{
 
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]

    public class BallContoller : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private Vector3 _firstInput;

        private Vector3 _secondInput;

        public float jumpForce = 5f;

        public bool isGrounded;
        
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

       
        void Update()
        {
          ReadInput();
        }

        void ReadInput()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _firstInput = Input.mousePosition;
                
                if (isGrounded)
                {
                    _rigidBody.AddForce(0f,jumpForce,0f,ForceMode.Impulse);
                }
            }

            if (Input.GetButton("Fire1"))
            {
                _secondInput = Input.mousePosition;
            }

            if (Input.GetButtonUp("Fire1"))
            {
               
                var result = _firstInput - _secondInput;
                var direction = result.x > 0f ? Vector3.right : result.x < 0f ? Vector3.left : Vector3.zero;
                Manager.GameManager.GlobalAccess.levelManager.RotateToLevel(direction:direction);
            }
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (collisionInfo.gameObject != null)
            {
              isGrounded = true;
         
            }
        }

        private void OnCollisionExit(Collision other)
        {
            isGrounded = false;
        }
    }

}