using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
public class dotwenntest : MonoBehaviour
{
    [SerializeField] Vector3 startRotate;
    [SerializeField] Vector3 endRotate;
    async void Start()
    {
        test().Forget();
        await UniTask.Delay(3000);
        test().Forget();
    }

    async UniTask test()
    {
        transform.DOLocalRotate(endRotate, 1f).SetEase(Ease.InOutSine);
        await UniTask.Delay(1000);
        transform.DOLocalRotate(startRotate, 1f).SetEase(Ease.InOutSine);
        await UniTask.Delay(1000);
        
    }
}
