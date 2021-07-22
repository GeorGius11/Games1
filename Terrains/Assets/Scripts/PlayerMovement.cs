using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    private Rigidbody _rb;
    private Vector3 _direction;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _direction = transform.TransformDirection(_direction);

        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        //if (Input.GetButton("W"))
        //{
        //    _direction.z = transform.forward.z;
        //}
    }

    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void Move(Vector3 direction)
    {
        _rb.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}