using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

public class BatteryManager : MonoBehaviour
{
    public static int battery = 100000;
    public int uiBattery;
    int minute;
    int second;

    void Update()
    {
        // Fが押されてbatteryが100以上の時100減らす
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (battery > 100)
            {
                battery -= 100;
            }
        }
        TimeRemaining();
    }
    void TimeRemaining()
    {
        minute = uiBattery / 60;
        second = uiBattery % 60;
    }

    void LateUpdate()
    {
        // UIバッテリーの値を更新
        uiBattery = battery;
    }

    void OnGUI()
    {
        // バッテリーの値を画面に表示
        GUI.Label(new Rect(10, 10, 200, 20), $"Battery: {uiBattery}");
        GUI.Label(new Rect(10, 30, 200, 20), $"残り: {minute}分");
        GUI.Label(new Rect(80, 30, 200, 20), $" {second}秒");
    }

    void Awake()
    {
        // 非同期タイマーを開始
        Timer(cts.Token).Forget();
    }

    // タイマーを停止するためのトークン
    CancellationTokenSource cts = new CancellationTokenSource();

    async UniTask Timer(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await UniTask.Delay(1000, cancellationToken: token);
            battery--;
            if (battery < 0) cts.Cancel(); // バッテリーが0未満になったらタイマーを停止
        }
    }
}

