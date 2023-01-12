using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private LayerMask GroundLayer = 1; // 1 == "Default"
    private CapsuleCollider _collider; // ������ ��������� ������������ CapsuleCollider
    //� ������� ���� ��������� ���� �� ����
    private bool _isGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

            //������� ��������� ���������� ������� � ��������� �� ���������� �� ��� ������ ������� ��������� � ����

            //_collider.bounds.size.x / 2 * 0.9f -- ��� �������� ����������� ����� ������ �������.
            // ��� �� ����������� ������ -- ������ �� ������ ��������, � ��� ����� ��-�������������

            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // ���� ����� ����� ������� � �������, �� ����� ����� �������� ���������� 0.9 �� �������.
        }
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _playerInput.Player.Jump.performed += ctx => Jump();

        _playerInput.Enable();
    }

    private void Jump()
    {
        if (_isGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
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
