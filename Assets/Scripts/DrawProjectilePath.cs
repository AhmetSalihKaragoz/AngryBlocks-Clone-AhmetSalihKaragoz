using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class DrawProjectilePath : MonoBehaviour
{
    
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private float _timeBetweenPoints;

    private GameObject[] points;
    private CannonShooter _cannonShooter;

    private bool _hasSpawned = false;

    public bool hasSpawned
    {
        get => _hasSpawned;
        set => _hasSpawned = value;
    }
    private void Start()
    {
        _cannonShooter = GetComponent<CannonShooter>();
    }

    private void Update()
    {
        CalculatePath();
    }

    public void SpawnPoints()
    {
        
        points = new GameObject[_cannonShooter.ballCount];
        for (int i = 0; i < _cannonShooter.ballCount; i++)
        {
            points[i] = Instantiate(pointPrefab, _cannonShooter.firePoint.position, quaternion.identity);
        }
        hasSpawned = true;
    }

    public void DestroyPoints()
    {
        for (int i = 0; i < _cannonShooter.ballCount; i++)
        {
            Destroy(points[i]);
        }
    }

    private void CalculatePath()
    {
        ChaseMouse();

        if (hasSpawned)
        {
            for (int i = 0; i<points.Length; i++)
            {
                points[i].transform.position = PointPosition(i * _timeBetweenPoints);
            }
        }
    }
    private void ChaseMouse()
    {
        transform.right = _cannonShooter.direction;
    }
    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)_cannonShooter.firePoint.position + (_cannonShooter.direction.normalized * (_cannonShooter.shootingPower * t))
                                  + Physics2D.gravity * (.5f * (t * t));
        return currentPointPos;
    }
}
