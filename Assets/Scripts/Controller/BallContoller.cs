using System.Timers;
using TunnelRush.LevelGenarator;
using Unity.Mathematics;
using UnityEngine.UIElements;

namespace TunnelRush.Controller
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]

    public class BallContoller : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private Vector3 _firstInput;

        private Vector3 _secondInput;
        

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            
        }

        // Update is called once per frame
        void Update()
        {
         ReadInput();
        }

        void ReadInput()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _firstInput = Input.mousePosition;

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

    }

}