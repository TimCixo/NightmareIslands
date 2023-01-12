using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IAttacktableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _visibleDistance;
    [SerializeField] private int _currentHitPoints;
    [SerializeField] private uint _damage;
    private bool _canAttack = true;

    private void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerController playerController))
        {
            Move(collider.gameObject);
        }
        if (TryAttack())
        {
            _canAttack = false;

            StartCoroutine(Reloading());
        }
    }

    private void Move(GameObject target)
    {
        Transform targetPosition = target.transform;
        Vector3 movement = new Vector3(0, 0, 1);

        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition.position) > _attackDistance)
        {
            Debug.Log("I moving");
            transform.Translate(movement * _moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log(Vector3.Distance(transform.position, targetPosition.position));
            Debug.Log(_attackDistance);
        }
    }

    private bool TryAttack()
    {
        if (_canAttack && Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _attackDistance))
        {
            if (hitInfo.transform.TryGetComponent(out InterfaceController interfaceController))
            {
                interfaceController.TakeDamage(_damage);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Reloading()
    {
        if (!_canAttack)
        {
            yield return new WaitForSecondsRealtime(_attackRate);

            _canAttack = true;
        }
    }

    public void Damaged(uint damage)
    {
        _currentHitPoints -= (int)damage;

        if (_currentHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHitPoints()
    {
        return _currentHitPoints;
    }
}
