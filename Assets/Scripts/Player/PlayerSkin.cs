using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private int id;
    public int Id => id;

    [SerializeField] private List<Transform> shootingPoints;
    public List<Transform> ShootingPoints =>shootingPoints;
    
}
