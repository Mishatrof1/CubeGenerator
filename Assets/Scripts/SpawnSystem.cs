using UnityEngine;

public static class SpawnSystem 
{
    public static void SpawnCube(GameObject _obj, Transform _position, float _speed, float _distance)
    {
        GameObject SpawnedCube =  Object.Instantiate(_obj, _position.transform.position, Quaternion.identity);
        Cube MotionCube = SpawnedCube.GetComponent<Cube>();
        MotionCube.Speed = _speed;
        MotionCube.MoveDistance = _distance;
    }
}
