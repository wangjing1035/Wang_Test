using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAreaCtl : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    [SerializeField] private GameMap gameMap;
    
    private const float minMove = 10;
    
    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    
  

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endPos = Input.acceleration;
    }

    private void CalSliderDir(Vector2 startPos, Vector2 endPos)
    {
        float xOffset = endPos.x - startPos.x;
        float yOffset = endPos.y - startPos.y;

        MoveDir dir = MoveDir.none;
        
        if (Mathf.Abs(xOffset) - Mathf.Abs(yOffset) >= 0)
        {
            if (xOffset > minMove )
            {
                dir = MoveDir.right;
            }
            else if (xOffset < -minMove)
            {
                dir = MoveDir.left;
            }
        }

        else
        {
            if (yOffset > minMove )
            {
                dir = MoveDir.up;
            }
            else if (yOffset < -minMove)
            {
                dir = MoveDir.down;
            }
        }
        
        gameMap.Move(dir);
    }
}


public enum MoveDir
{
    none,
    up,
    down,
    left,
    right
}