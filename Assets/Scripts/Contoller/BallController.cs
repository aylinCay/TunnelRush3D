using static UnityEngine.Vector3;

namespace TunnelGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BallController : MonoBehaviour
    {
        public Rigidbody rigidBody;

        public Vector3 forward;
        public float moveSpeed = 20f;
        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
       }

        // Update is called once per frame
        void Update()
        {
            rigidBody.AddForce(Vector3.forward * moveSpeed * Time.deltaTime);
        }

       
          
        
    }

    
}