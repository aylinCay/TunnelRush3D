using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace TunnelRush.LevelGenarator
{
  public class TileController : MonoBehaviour
  {
    public Vector3 firstPosition;
    public Vector3 callPosition;
    public float tweenDuration = .5f;
    public MeshRenderer meshRenderer;
    public Transform pivot;

    private float _tDuration;

    public void Start()
    {
      pivot = transform.GetChild(0);
      if (meshRenderer == null)
      {
        meshRenderer = GetComponent<MeshRenderer>();
      }

      _tDuration = Random.Range(tweenDuration * .9f, tweenDuration * 1.1f);

      var parent = transform.parent.GetComponent<LevelBlock>();
      parent.hideEvent.AddListener(Hide);
      parent.moveCallPositionEvent.AddListener(MoveCallPosition);
      parent.saveCallPositionEvent.AddListener(SaveCallPosition);
      parent.moveFirstPositionEvent.AddListener(MoveFirstPosition);
    }

    public void Hide(bool isOn)
    {
      meshRenderer.enabled = !isOn;
    }

    public void SaveCallPosition()
    {
      callPosition = pivot.transform.position;
    }

    public void MoveCallPosition()
    {
      transform.position = callPosition;
    }

    public void MoveFirstPosition()
    {
      transform.DOLocalMove(firstPosition, _tDuration, false);
    }

    private void OnEnable()
    {
      firstPosition = transform.localPosition;
    }

   
  }

}