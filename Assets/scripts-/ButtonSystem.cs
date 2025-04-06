using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ButtonSequence : MonoBehaviour
{
    private string correctOrder = "1234567891011121314"; // 正しい順番
    private string correctOrder2 = "111"; // 正しい順番
    private string currentInput = "";   // プレイヤーの入力を記録

    public Button[] buttons; // ボタンを配列で管理
    public RectTransform canvasRect; // ボタン配置用のCanvas
    public Canvas canvas;
    public GameObject deleteCanvas;
    
    void Start()
    {
        ShuffleButtons();
        foreach (Button button in buttons)
        {
            string letter = button.name; // ボタンの名前を取得 (A, B, C, ...)
            button.onClick.AddListener(() => ButtonPressed(letter));
        }
    }

    void ButtonPressed(string letter)
    {
        currentInput += letter;

        if (correctOrder.StartsWith(currentInput) || correctOrder2.StartsWith(currentInput))
        {
            if (currentInput == correctOrder || currentInput == correctOrder2)
            {
                if (correctOrder.StartsWith(currentInput))
                {
                    Debug.Log("Clear!");
                }

                if (correctOrder2.StartsWith(currentInput))
                {
                    Debug.Log("");
                }
                
                ResetGame(); // 正解したらリセット
                canvas.enabled = false;
            }
        }
        else
        {
            Debug.Log("Miss! Try again.");
            ResetGame(); // 間違えたらリセット
        }
    }

    void ResetGame()
    {
        currentInput = "";
        ShuffleButtons();
    }

    void ShuffleButtons()
    {
        List<Vector2> positions = new List<Vector2>();

        // 各ボタンの元の位置を保存
        foreach (Button button in buttons)
        {
            positions.Add(button.GetComponent<RectTransform>().anchoredPosition);
        }

        // 位置をシャッフル
        for (int i = 0; i < positions.Count; i++)
        {
            int randomIndex = Random.Range(0, positions.Count);
            (positions[i], positions[randomIndex]) = (positions[randomIndex], positions[i]);
        }

        // 新しい位置を適用
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<RectTransform>().anchoredPosition = positions[i];
        }
    }
}