using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public float shootingPower;
    public Transform firePoint;
    public bool readyToShot = true;
    [HideInInspector] public Vector2 direction;
    
    
    [SerializeField] private GameObject cannonBallPrefab;

    [HideInInspector] public int ballCount = 6;

    private List<GameObject> _cannonBallList = new List<GameObject>();
    private DrawProjectilePath _drawProjectilePath;
    
    private void Start()
    {
        _drawProjectilePath = GetComponent<DrawProjectilePath>();
    }
    private void Update()
    {
        RotateCannon();
        SpawnCannonBalls();
        StartCoroutine(Shoot());
    }
    private  IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        var cachedVelocity = firePoint.transform.right * shootingPower;
        
        if (Input.GetMouseButtonUp(0))
        {
            _drawProjectilePath.DestroyPoints();
            StartCoroutine(UpdateShootingState());
            for (int i = 0; i < _cannonBallList.Count; i++)
            {
                _cannonBallList[i].GetComponent<Rigidbody2D>().velocity = cachedVelocity;
                _cannonBallList[i].GetComponent<BallController>()._renderer.enabled = true;
                _drawProjectilePath.hasSpawned = false;
                yield return wait;
            }
            _cannonBallList.Clear();
            
        }
    }

    private void SpawnCannonBalls()
    {
        if (readyToShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _drawProjectilePath.SpawnPoints();
                if (_cannonBallList.Count == 0)
                {
                    for (int i = 0; i < ballCount; i++)
                    {
                        var cannonBallInstance = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);
                        cannonBallInstance.GetComponent<BallController>()._renderer.enabled = false;
                        _cannonBallList.Add(cannonBallInstance);
                    }
                }
            }
        }
    }
    private void RotateCannon()
    {
        if (readyToShot)
        {
            direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    
    private  IEnumerator UpdateShootingState()
    {
        readyToShot = false;
        yield return new WaitForSeconds(5f);
        readyToShot = true;
    }
    
    
}
