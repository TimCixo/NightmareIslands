using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool _isAlive = true;
    public bool IsAlive => _isAlive;

    [SerializeField] private Canvas _deathScreen;

    private InterfaceController _interfaceController;

    private PlayerMove _playerMove;
    private PlayerLook _playerLook;
    private PlayerBattle _playerBattle;

    private void Start()
    {
        _interfaceController = GetComponent<InterfaceController>();
        _playerMove = GetComponent<PlayerMove>();
        _playerLook = GetComponent<PlayerLook>();
        _playerBattle = GetComponent<PlayerBattle>();
        Cursor.visible = false;

        Vector3 startIslandPosition = GameObject.Find("StartIsland(Clone)").transform.position;
        startIslandPosition.y += 1;

        transform.position = startIslandPosition;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -10 && _isAlive)
        {
            _interfaceController.TakeDamage(1);
        }
    }

    public void Death()
    {
        _isAlive = false;
        _playerMove.enabled = false;
        _playerLook.enabled = false;
        _playerBattle.enabled = false;

        Cursor.visible = true;

        Instantiate(_deathScreen);
    }
}
