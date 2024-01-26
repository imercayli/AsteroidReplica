using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    private Rect innerBox;
    private Rect outerBox;
    [SerializeField] private float outerBoxOffset = 2f;
    public GameObject imer; 

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        for (int i = 0; i < 20; i++)
        {
            var imerr = Instantiate(imer);
            imerr.transform.position = GetSpawnPosition();
        }

    }

   private Vector2 GetSpawnPosition()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(screenSize.x, screenSize.y));

         innerBox = new Rect(-screenBounds.x, -screenBounds.y, screenBounds.x * 2, screenBounds.y * 2);
         outerBox = new Rect(innerBox.xMin - outerBoxOffset, innerBox.yMin - outerBoxOffset, innerBox.width + outerBoxOffset * 2, innerBox.height + outerBoxOffset * 2);

        Vector2 spawnPosition;
        do
        {
            float x = Random.Range(outerBox.xMin, outerBox.xMax);
            float y = Random.Range(outerBox.yMin, outerBox.yMax);
            spawnPosition = new Vector2(x, y);
        } 
        while (innerBox.Contains(spawnPosition));

        return spawnPosition;
    }
   
   void OnDrawGizmos()
   {
       Camera mainCamera = Camera.main;
       if (!mainCamera) return;

       // Calculate screen bounds in world coordinates
       float vertExtent = mainCamera.orthographicSize;
       float horzExtent = vertExtent * Screen.width / Screen.height;

       // Inner box (screen size)
       Vector3 bottomLeft = mainCamera.transform.position - new Vector3(horzExtent, vertExtent, 0);
       Vector3 topLeft = mainCamera.transform.position + new Vector3(-horzExtent, vertExtent, 0);
       Vector3 bottomRight = mainCamera.transform.position + new Vector3(horzExtent, -vertExtent, 0);
       Vector3 topRight = mainCamera.transform.position + new Vector3(horzExtent, vertExtent, 0);

       Gizmos.color = Color.red;
       Gizmos.DrawLine(bottomLeft, topLeft);
       Gizmos.DrawLine(topLeft, topRight);
       Gizmos.DrawLine(topRight, bottomRight);
       Gizmos.DrawLine(bottomRight, bottomLeft);

       // Outer box
       Vector3 outerBottomLeft = bottomLeft - new Vector3(outerBoxOffset, outerBoxOffset, 0);
       Vector3 outerTopLeft = topLeft + new Vector3(-outerBoxOffset, outerBoxOffset, 0);
       Vector3 outerBottomRight = bottomRight + new Vector3(outerBoxOffset, -outerBoxOffset, 0);
       Vector3 outerTopRight = topRight + new Vector3(outerBoxOffset, outerBoxOffset, 0);

       Gizmos.color = Color.green;
       Gizmos.DrawLine(outerBottomLeft, outerTopLeft);
       Gizmos.DrawLine(outerTopLeft, outerTopRight);
       Gizmos.DrawLine(outerTopRight, outerBottomRight);
       Gizmos.DrawLine(outerBottomRight, outerBottomLeft);
   }
}

