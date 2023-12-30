using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CanvasObjHolder : MonoBehaviour
{
    //FPS camera is assigned to canvas for better Input
    [SerializeField] Camera _mainCamera;
    [SerializeField] Canvas _canvas;
    void Start()
    {
        Task task = GetObj();
    }
    public async Task GetObj()
    {
       await Task.Delay(3000);
        _mainCamera = FindObjectOfType<CharacterController>().GetComponentInChildren<Camera>();
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = _mainCamera;
    }
}
