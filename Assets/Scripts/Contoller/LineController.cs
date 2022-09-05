using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace TunnelGame
{


    public class LineController : MonoBehaviour
    {
       
        private float moveSpeed = 5f;
        private Vector3 newpos;
        public GameObject startPivot;
        
        public void Start()
        {

            
        }

        public void Creator()
        {
            var platformCount = transform.childCount;
            for (int j = platformCount - 3; j >= 0; j--)
            {
                var platform= transform.GetChild(j).gameObject;
                platform.SetActive(false);
            }
            
           transform.rotation = Quaternion.Euler(0,0,45);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Creator();
                transform.position += new Vector3(0, 0, 15);
            }
        }
    }
}
