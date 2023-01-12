using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private Canvas _interface;
     private Canvas _instantiateInterface;

    private static readonly int _maxHitPoints = 100;
    private static readonly int _minHitPoints = 0;
    private static int _currentHitPoints = _maxHitPoints;

    [SerializeField] private float _detectDistance;

    private GameObject _hitPoints;
    private GameObject _enemyHitPoints;
    private GameObject _inventoryPanel;
    private GameObject _level;

    private GameObject _head;

    private PlayerController _playerController;
    private PlayerBattle _playerBattle;
    private Inventory _inventory;

    private void Start()
    {
        _instantiateInterface = Instantiate(_interface);

        _hitPoints = _instantiateInterface.transform.Find("HP").gameObject;
        _enemyHitPoints = _instantiateInterface.transform.Find("EnemyHitPoints").gameObject;
        _inventoryPanel = _instantiateInterface.transform.Find("Inventory").gameObject;
        _level = _instantiateInterface.transform.Find("Level").gameObject;
        _head = transform.Find("Head").gameObject;

        _playerController = transform.GetComponent<PlayerController>();
        _playerBattle = transform.GetComponent<PlayerBattle>();
        _inventory = transform.GetComponent<Inventory>();

        _hitPoints.GetComponent<Text>().text = $"HP: {_currentHitPoints}";
        _level.GetComponent<Text>().text = $"{SceneManager.GetActiveScene().buildIndex}";
        _enemyHitPoints.GetComponent<Text>().text = "";
    }

    private void FixedUpdate()
    {
        _inventoryPanel.GetComponent<Text>().text = $"Crystal: {_inventory.CrystallCount}\nOre: {_inventory.OreCount}";

        if (_currentHitPoints <= _minHitPoints && _playerController.IsAlive)
        {
            _instantiateInterface.enabled = false;

            transform.GetComponent<PlayerController>().Death();
        }
        if (Physics.Raycast(_head.transform.position, _head.transform.forward, out RaycastHit hitInfo, _detectDistance, -1, QueryTriggerInteraction.Ignore))
        {
            if (hitInfo.transform.TryGetComponent(out IAttacktableObject attacktableObject))
            {
                _enemyHitPoints.GetComponent<Text>().text = $"HP: {attacktableObject.GetHitPoints()}";
            }
            else
            {
                _enemyHitPoints.GetComponent<Text>().text = $"";
            }
        }
        else
        {
            _enemyHitPoints.GetComponent<Text>().text = $"";
        }
    }

    public void TakeDamage(uint damage)
    {
        _currentHitPoints -= (int)damage;

        _hitPoints.GetComponent<Text>().text = $"HP: {_currentHitPoints}";
    }
    public void TakeHeal(uint heal)
    {
        _currentHitPoints = Mathf.Clamp(_currentHitPoints + ((int)heal), _minHitPoints, _maxHitPoints);

        _hitPoints.GetComponent<Text>().text = $"HP: {_currentHitPoints}";
    }

    public static void SetDefault()
    {
        _currentHitPoints = _maxHitPoints;
    }
}
