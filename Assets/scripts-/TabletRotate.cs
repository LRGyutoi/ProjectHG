using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class CubeRotate : MonoBehaviour
{
    public float y = 1f;
    
    void Awake()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void OnEnable()
    {
        DOTween.Kill(this);
        transform.DOLocalRotate(new Vector3(0,0,0), 0.5f);
    }

    void OnDisable()
    {
        DOTween.Kill(this);
        transform.DOLocalRotate ( new Vector3(0,180,0), 0.5f);
       
    }
}
