using System.Collections;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    private PlayerInput _playerInput;
    private GameObject _head;
    [SerializeField] private float _attackDistance;
    [SerializeField] private uint _damage;
    [SerializeField] private uint _resistance;
    private bool _canAttack;

    public uint Resistance => _resistance;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _head = GameObject.Find("Head");

        _playerInput.Enable();

        _playerInput.Player.Attack.performed += ctx => Attack();
        _playerInput.Player.Block.performed += ctx => Block();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Attack()
    {
        if (Physics.Raycast(_head.transform.position, _head.transform.forward, out RaycastHit hitInfo, _attackDistance, -1, QueryTriggerInteraction.Ignore))
        {
            if (hitInfo.transform.TryGetComponent(out IAttacktableObject attacktableObject))
            {
                attacktableObject.Damaged(_damage);
            }
        }
    }

    private void Block()
    {
    }
}
