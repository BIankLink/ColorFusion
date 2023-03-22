using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{

    
    //private Camera cam;
    [SerializeField] private Line linePrefab;

    public const float RESOLUTION = 0.1F;

    private Line currentLine;
    

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {


            if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                currentLine = Instantiate(linePrefab, touchPos, Quaternion.identity);
            }
            if (Input.GetMouseButton(0) || Input.touchCount > 0)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                currentLine.SetPosition(touchPos);
            }
        }
    }
    

}
