using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput _playerInput;
    private GameObject _head;
    private float _interactDistance = 1f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _head = GameObject.Find("Head");

        _playerInput.Enable();

        _playerInput.Player.Use.performed += ctx => Use();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Use()
    {
        if (Physics.Raycast(_head.transform.position, _head.transform.forward, out RaycastHit hitInfo, _interactDistance))
        {
            if (hitInfo.transform.TryGetComponent(out IUsableObject usableObject))
            {
                usableObject.Use(this.gameObject);
            }
        }
    }
}
