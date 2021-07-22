using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //[SerializeField] private float _sensivity = 10.0f;
    [SerializeField] private GameObject _player;

    private Vector3 _direction;

    private void Update()
    {
        _direction = new Vector3(Input.GetAxis("Mouse Y"), 0, 0);
        transform.Rotate((-1)*_direction.x, 0, 0);
        //_player.transform.Rotate(0, _direction.y, 0);
    }
}
