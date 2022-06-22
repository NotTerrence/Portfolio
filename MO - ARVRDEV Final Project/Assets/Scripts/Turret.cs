using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 0.7f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform PartToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform[] firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f,  0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 90f);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    { 
        for (int i = 0; i < firePoint.Length; i++)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if(bullet != null)
                bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}