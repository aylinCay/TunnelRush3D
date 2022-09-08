using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TunnelRush.LevelGenarator
{
    public class LevelBlock : MonoBehaviour
    {
       
        private float _rotateAngle = 0f;

        private bool _isRotate;

        private Quaternion _targetRotation;
       
        
        public float Speed{ get; set; } = 3f;

        [Range(0, 2)] public int variantFactor = 1;

        public float rotateAngle
        {
            get
            {
                if (_rotateAngle <= 0f)
                   _rotateAngle = 360f / (float)tiles.Count;
                return _rotateAngle;
            }
        }
        public List<GameObject> tiles = new List<GameObject>();

        public void Start()
        {
            Manager.GameManager.GlobalAccess.levelManager.rotateListeners.AddListener(this.RotateBlock);
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
            for (int i = 0; i < variantFactor;i++)
            {
                var randIndex = Random.Range(0, tiles.Count -1);
                tiles[randIndex].SetActive(false);
                
            }
        }

        public void MakeDefault()
        {
            foreach (var tile in tiles)
            {
                tile.SetActive(true);
                
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