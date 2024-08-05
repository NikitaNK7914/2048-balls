using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float maxX;
    private float oldX;
    private float _x;
    private Vector3 GetWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -_camera.transform.position.z;
        Vector3 worldPos = _camera.ScreenToWorldPoint(mousePos);
        return worldPos;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldX = GetWorldPos().x;
        }
        if (Input.GetMouseButton(0))
        {
            float x= GetWorldPos().x;
            float deltaX = x - oldX;
            oldX = x;
            _x += deltaX;
            _x= Mathf.Clamp(_x,-maxX,maxX);
            transform.position=new Vector3(_x,transform.position.y,0f);
        }
        
    }
    
}
