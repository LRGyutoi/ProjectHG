using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorToggle : MonoBehaviour
{
    void Update()
    {
        // 左クリックでカーソルを非表示にしてロックする
        if (Input.GetMouseButtonDown(0)) // 0は左クリック
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; // カーソルを画面中央に固定
        }

        // 右クリックでカーソルを表示してロック解除する
        if (Input.GetMouseButtonDown(1)) // 1は右クリック
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; // ロック解除
        }
    }
}

