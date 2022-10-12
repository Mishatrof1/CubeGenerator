using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreSystem : MonoBehaviour
{
    public static GameCoreSystem instance;

    
    public GameObject Prefab => prefabsData.prefab;

    public float SpawnTimeValue  { get => _spawnTime; set => _spawnTime = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public int MoveDistance { get => _moveDistance; set => _moveDistance = value; }

    [SerializeField] private float _speed = 1f;
    [SerializeField] private int _moveDistance = 10;
    [SerializeField] private float _spawnTime = 10f;

    [SerializeField] private PrefabsData prefabsData;
    [SerializeField] private Transform SpawnPosition;

    private bool _isPlayed;
    private IEnumerator _createCubeCoroutine;

    private void Awake()
    {
            instance = this;
    }


    public void Play()
    {
        if (_isPlayed)
            return;

        _isPlayed = true;

        _createCubeCoroutine = SpawnObject();

        StartCoroutine(_createCubeCoroutine);
    }

    public void Stop()
    {
        StopCoroutine(_createCubeCoroutine);

        _isPlayed = false;
    }
    public void UpdateData(float _createTime, float _cubeSpeed, int _moveDistance)
    {
        this._speed = _cubeSpeed;
        this._spawnTime = _createTime;
        this._moveDistance = _moveDistance;
    }
    private IEnumerator SpawnObject()// Спавн N раз в секунду 
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _spawnTime);
            SpawnSystem.SpawnCube(Prefab, SpawnPosition, this._speed, this._moveDistance);
        }
    }
}
