using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    public float Speed { get => _speed; set => _speed = value; }
    public float MoveDistance { get => _moveDistance; set => _moveDistance = value; }

    [SerializeField]
    private float _speed = 1f;

    [SerializeField]
    private float _moveDistance = 10f;

    private Vector3 _startPosition;
    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Move();
        CheckDistance();
    }

    private void Move()
    {
        Vector3 moveVector = transform.forward * _speed * Time.deltaTime;

        transform.position += moveVector;
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, _startPosition);

        if (distance >= _moveDistance)
            Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
