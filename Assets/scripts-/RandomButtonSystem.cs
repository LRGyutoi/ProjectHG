using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomButtonSpawner : MonoBehaviour
{
    public GameObject[] buttonPrefabs; // すべてのボタンPrefab
    public RectTransform canvasRect;   // UIのCanvas

    void Start()
    {
        SpawnAllButtons();
    }

    void SpawnAllButtons()
    {
        List<Vector2> usedPositions = new List<Vector2>(); // 使われた位置リスト

        foreach (GameObject prefab in buttonPrefabs)
        {

            // 被らないランダムな位置を取得
            Vector2 randomPos;
            int maxAttempts = 100; // 無限ループを防ぐため
            int attempt = 0;

            do
            {
                randomPos = new Vector2(
                    Random.Range(-canvasRect.rect.width / 2, canvasRect.rect.width / 2),
                    Random.Range(-canvasRect.rect.height / 2, canvasRect.rect.height / 2)
                );
                attempt++;
            } while (usedPositions.Contains(randomPos) && attempt < maxAttempts);

            usedPositions.Add(randomPos);
        }
    }
}
