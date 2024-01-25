using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
   [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
       SetBackgroundScale();
    }

    private void SetBackgroundScale()
    {
        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 imageScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
        transform.localScale = imageScale;
    }
}
