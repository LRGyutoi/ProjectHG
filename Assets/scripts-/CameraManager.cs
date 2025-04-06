using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject cameraPrefab;
    public GameObject activeCamera;
    public GameObject gameObj;
    public int activeCameraIndex = -1;

    private List<GameObject> _cameras = new();

    void Start()
    {
        activeCamera = null;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUpCamera();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (BatteryManager.battery > 100)
            {
                CreateCamera();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeNextActiveCamera();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePreviousActiveCamera();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Tablet();
        }
    }
    ///<summary>タブレットの表示非表示</summary>
    void Tablet()
    {
        if (gameObj.activeSelf)
        {
            gameObj.SetActive(false);
        }
        else if (!gameObj.activeSelf)
        {
            gameObj.SetActive(true);
        }
    }
    ///<summary>カメラを生成して番号の割り当て</summary>
    void CreateCamera()
    {
        GameObject newCamera = Instantiate(cameraPrefab, transform.position, transform.rotation);
        _cameras.Add(newCamera);
        newCamera.name = "Camera" + _cameras.Count;
        newCamera.gameObject.SetActive(false);

        if (!activeCamera)
        {
            activeCamera = newCamera;
            activeCameraIndex = 0;
            activeCamera.SetActive(true);
        }
    }
    ///<summary>アクティブ状態のカメラを次のカメラに切り替え</summary>
    void ChangeNextActiveCamera()
    {
        if (_cameras.Count == 0) return;

        activeCamera.gameObject.SetActive(false);
        activeCameraIndex++;
        if (activeCameraIndex >= _cameras.Count) activeCameraIndex = 0;
        activeCamera = _cameras[activeCameraIndex];
        activeCamera.SetActive(true);
    }
    ///<summary>アクティブ状態のカメラを前のカメラに切り替え</summary>
    void ChangePreviousActiveCamera()
    {
        if (_cameras.Count == 0) return;

        activeCamera.gameObject.SetActive(false);
        activeCameraIndex--;
        if (activeCameraIndex < 0) activeCameraIndex = _cameras.Count - 1;
        activeCamera = _cameras[activeCameraIndex];
        activeCamera.SetActive(true);
    }
    ///<summary>カメラを拾う</summary>
    void PickUpCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Rayがオブジェクトに当たった場合
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.CompareTag("Camera"))
        {
            Debug.Log("aaa");
        }
    }
}