using UnityEngine;
using Unity.Mathematics;

public class DrawProjectilePath : MonoBehaviour
{
    
    [SerializeField] private GameObject pointPrefab;

    private GameObject[] _points;
    private CannonShooter _cannonShooter;

    private readonly float _timeBetweenPoints = 0.12f;
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
        
        _points = new GameObject[_cannonShooter.ballCount];
        for (int i = 0; i < _cannonShooter.ballCount; i++)
        {
            _points[i] = Instantiate(pointPrefab, _cannonShooter.firePoint.position, quaternion.identity);
        }
        hasSpawned = true;
    }

    public void DestroyPoints()
    {
        for (int i = 0; i < _cannonShooter.ballCount; i++)
        {
            Destroy(_points[i]);
        }
    }

    private void CalculatePath()
    {
        ChaseMouse();

        if (hasSpawned)
        {
            for (int i = 0; i<_points.Length; i++)
            {
                _points[i].transform.position = PointPosition(i * _timeBetweenPoints);
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
