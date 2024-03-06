using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DrawLine drawLine;
    [SerializeField] private UIManager uiManager ;
    [SerializeField] private CircleManager CircleManager;
    public static HashSet<GameObject> circles = new ();
    public static bool isGameStarted = false;

    private void Start()
    {
        uiManager.ChangeState(UIManager.UIState.StartGameMenuState);
    }

    private void Update()
    {
        if (!isGameStarted)return;
        
        if (circles.Count==0 )
        { 
            uiManager.ChangeState(UIManager.UIState.ResetGameMenuState);
        }
        if (Input.GetMouseButton(0) )
        {
            Debug.Log($"Raycasting");
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 5f;
            
            drawLine.Draw(pos);
            
        } else if (Input.GetMouseButtonUp(0))
        {
            drawLine.Raycast();
        }
    }
}