using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawningObject;
    [Range(0, 100)][SerializeField] private int _chance;

    private void Start()
    {
        Randomization();
    }

    private void Randomization()
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber <= _chance)
        {
            GameObject gameObject = Instantiate(_spawningObject);

            gameObject.transform.position = default;
            gameObject.transform.SetParent(transform, false);
        }
    }
}
