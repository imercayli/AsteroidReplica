using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player _player;
   private List<Transform> shootingPositions;
   [SerializeField] [Range(0,1)] private float fireRate;
   private float fireTime;
    public GameObject bulletPrefab;
    
    public PlayerAttack Initialize(Player player)
    {
        _player = player;
        shootingPositions = _player.CurrentSkin.ShootingPoints;
        return this;
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Time.time<fireTime) return;
        fireTime = Time.time + fireRate;
        // BulletBase bullet = bulletObjectPooling.GetObjectFromPool();
        // bullet.transform.SetParent(null);

        foreach (Transform shootingPosition in shootingPositions)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootingPosition.transform.position;
            bullet.transform.rotation = shootingPosition.transform.rotation;
        }
      
       // bullet.Initialize(characterBase, characterBase);//todo
    }
}
