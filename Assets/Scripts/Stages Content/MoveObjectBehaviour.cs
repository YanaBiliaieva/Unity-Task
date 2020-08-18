using UnityEngine;

public class MoveObjectBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;

    private Vector2 _direction = Vector2.zero;

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _direction, step);
    }

    private void OnMouseDown()
    {
        _direction = GetRandomPoint();
    }

    private Vector2 GetRandomPoint()
    {
        var randPosX = Random.Range(CameraHelper.leftOffsetX, CameraHelper.rightOffsetX);
        var randPosY = Random.Range(CameraHelper.bottomOffsetY, CameraHelper.topOffsetY);
        return new Vector2(randPosX, randPosY);
    }
}