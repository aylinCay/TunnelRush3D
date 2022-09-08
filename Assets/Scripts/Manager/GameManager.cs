using System;
using TunnelRush.LevelGenarator;
using UnityEngine;

namespace TunnelRush.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GlobalAccess { get; private set; }
        public LevelManager levelManager { get; set; }
        
        [SerializeField]
        private float _gameSpeed;

        [SerializeField] private float _levelRotateSpeed;
        [SerializeField] private float _playerJump;

        public float gameSpeed => _gameSpeed;

        public float levelRotateSpeed => _levelRotateSpeed;
        public float playerJump => _playerJump;

        private void Awake()
        {
            GlobalAccess = this;
        }
    }
    
}