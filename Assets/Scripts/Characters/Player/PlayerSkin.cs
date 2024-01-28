using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int id;
    public int Id => id;

    [SerializeField] private List<Transform> shootingPoints;
    public List<Transform> ShootingPoints =>shootingPoints;
    
    public void Reborn(float time)
    {
        spriteRenderer.DOFade(.2f, time / 5).From(0).SetLoops(4, LoopType.Yoyo).OnComplete((() =>
        {
            spriteRenderer.DOFade(1, .5f);
        }));
    }
    
}
