using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace TunnelRush.LevelGenarator
{
    public class LevelBlock : MonoBehaviour
    {
       
        private float _rotateAngle = 0f;

        private bool _isRotate;

        private Quaternion _targetRotation;

        public float timer = 0f;
        private int randCount;
        
        public float Speed{ get; set; } = 3f;

        [Range(0, 2)] public int variantFactor = 1;
        
        public UnityEvent<bool> hideEvent = new UnityEvent<bool>();
        public UnityEvent moveCallPositionEvent = new UnityEvent();
        public UnityEvent saveCallPositionEvent = new UnityEvent();
        public UnityEvent moveFirstPositionEvent = new UnityEvent();

        public float rotateAngle
        {
            get
            {
                if (_rotateAngle <= 0f)
                   _rotateAngle = 360f / (float)tiles.Count;
                return _rotateAngle;
            }
        }
        public List<TileController> tiles = new List<TileController>();

        public void Start()
        {
           LevelManager.GlobalAccsess.rotateListeners.AddListener(this.RotateBlock);
        }

        public void Update()
        {
            randCount = Random.Range(0, tiles.Count -1);
            timer++;
            
            MakeDefault();
            if (timer >= 5f)
            {
                CreaterVariation();
                timer = 0f;
            }
        }

        private void FixedUpdate()
        {
          
            transform.position += Vector3.back * Speed * Time.deltaTime;

            if (_isRotate)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,_targetRotation,
                    Manager.GameManager.GlobalAccess.levelRotateSpeed * Time.deltaTime);
                _isRotate = (transform.rotation.eulerAngles.z != _targetRotation.eulerAngles.z);
            }
        }

        public void CreaterVariation()
        {
            if (transform.position.z <=-4) 
            for (int i = 0; i < variantFactor;i++)
            {
              var randIndex = Random.Range(0,tiles.Count - randCount);
                tiles[randIndex].gameObject.SetActive(false);
                
            }
        }

        public void MakeDefault()
        {
            if(transform.position.z >= 0 && transform.position.z <= 2f)
            foreach (var tile in tiles)
            {
                tile.gameObject.SetActive(true);
                
            }
        }

        public void RotateBlock(Vector3 direction)
        {
            var angle = transform.rotation.eulerAngles.z + (rotateAngle * direction.x);
         _targetRotation = Quaternion.Euler(Vector3.forward * angle);
           _isRotate = true;


        }
    }
}