using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private float _minimalAngle = -90;
    private float _maximalAngle = 90;

    private PlayerInput _playerInput;

    private Vector2 _rotate;
    private Vector2 _rotation;
    private Vector2 _headRotation;

    private GameObject _head;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _head = GameObject.Find("Head");

        _playerInput.Enable();
    }

    private void FixedUpdate()
    {
        _rotate = _playerInput.Player.Look.ReadValue<Vector2>();

        Rotation(_rotate);
    }

    private void Rotation(Vector2 rotate)
    {
        float scaledRotateSpeed = _rotateSpeed * Time.fixedDeltaTime;

        _rotation.y += rotate.x * scaledRotateSpeed;
        _headRotation.x = Mathf.Clamp(_headRotation.x - rotate.y * scaledRotateSpeed, _minimalAngle, _maximalAngle);

        transform.localEulerAngles = _rotation;
        _head.transform.localEulerAngles = _headRotation;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
