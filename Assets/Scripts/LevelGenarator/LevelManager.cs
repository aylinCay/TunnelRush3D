using System;
using UnityEngine.Events;

namespace TunnelRush.LevelGenarator
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LevelManager : MonoBehaviour
    {
       public static LevelManager GlobalAccsess { get; set; }

       public UnityEvent<Vector3> rotateListeners = new UnityEvent<Vector3>();
       
       public float zPositionDiff = 4.2f;
       
       public float zPosition = 12.6f;

       public List<LevelBlock> blocks = new List<LevelBlock>();

       private void Awake()
       {
           GlobalAccsess = this;
       }

       private void Start()
       {
           Manager.GameManager.GlobalAccess.levelManager = this;
       }

       private void Update()
       {
           SortBlock();
       }

       public void SortBlock()
       {
           var selected = blocks[^1];

           if (selected.transform.position.z <= zPosition)
           {
               var first = blocks[0];
               first.hideEvent.Invoke(true);
               first.transform.position = selected.transform.position + (Vector3.forward * zPositionDiff);
               blocks.RemoveAt(0);
               blocks.Add(first);
               first.saveCallPositionEvent.Invoke();
               first.moveCallPositionEvent.Invoke();
               first.hideEvent.Invoke(false);
               first.moveFirstPositionEvent.Invoke();

           }
           
       }

       public void RotateToLevel(Vector3 direction)
       {
           rotateListeners.Invoke(direction);
       }

       
       
    }

}