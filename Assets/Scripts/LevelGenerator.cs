using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int[] _vector = {-1, 1};
    [SerializeField] private int _largeIslandCount;
    [SerializeField] private int _mediumIslandCount;
    [SerializeField] private int _smallIslandCount;
    [SerializeField] private int _chanceToSpawnIsland;

    private GameObject[,] _map;
    [SerializeField] private GameObject _largeIsland;
    [SerializeField] private GameObject _smallIsland;
    [SerializeField] private GameObject _mediumIsland;
    [SerializeField] private GameObject _startIsland;
    [SerializeField] private GameObject _finalIsland;

    [SerializeField] private GameObject _bridge;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        Generate();
        Output();
    }

    private void Output()
    {
        int arrayHeight = _map.GetLength(0);
        int arrayWidth = _map.GetLength(1);
        int center = arrayWidth / 2;

        int indent = 10;

        float bridgeHeight = 0.59f;

        for (int i = 0; i < arrayHeight; i++)
        {
            for (int j = 0; j < arrayWidth; j++)
            {
                if (_map[i, j] != null)
                {
                    Instantiate(_map[i, j], new Vector3(j * 10, 0, i * 10), new Quaternion());

                    if (_map[i, j + 1] != null)
                    {
                        GameObject bride = Instantiate(_bridge, new Vector3(j * indent + indent / 2, bridgeHeight, i * indent), new Quaternion());

                        bride.transform.Rotate(0, 90, 0, 0);
                        bride.transform.localScale += new Vector3(0, 0, 0.5f);
                    }

                    if (i > 0 && j == center)
                    {
                        GameObject bride = Instantiate(_bridge, new Vector3(j * indent, bridgeHeight, i * indent - indent / 2), new Quaternion());
                    }
                }
            }
        }

        Instantiate(_player, _startIsland.transform.position, new Quaternion());
    }

    private void Generate()
    {
        int arrayHeight = _largeIslandCount + 2;
        int arrayWidth = (_smallIslandCount + _mediumIslandCount) * 2 + 3;
        int center = arrayWidth / 2;

        _map = new GameObject[arrayHeight, arrayWidth];

        // Заполнение центрального ряда
        for (int i = 0; i < arrayHeight; i++)
        {
            _map[i, center] = _largeIsland;
        }

        // Начальный и конечный острова
        _map[0, center] = _startIsland;
        _map[arrayHeight - 1, center] = _finalIsland;

        // Заполнение островами
        AddMoreIslands(_smallIsland, _smallIslandCount);
        AddMoreIslands(_mediumIsland, _mediumIslandCount);

    }

    private void AddMoreIslands(GameObject island, int count)
    {
        int arrayHeight = _map.GetLength(0);
        int arrayWidth = _map.GetLength(1);
        int center = arrayWidth / 2;

        for (int i = 0; i < count;)
        {
            for (int j = 1; j < arrayHeight - 1; j++)
            {
                if (Randomization(_chanceToSpawnIsland))
                {
                    int vector = _vector[Random.Range(0, 2)];

                    _map[j, GetFreePosition(vector, j, center)] = island;
                    i++;
                    break;
                }
            }
        }
    }

    private int GetFreePosition(int vector, int selectedRow, int selectedColumn)
    {
        int selected = selectedColumn;

        while (true)
        {
            selected += vector;

            if (_map[selectedRow, selected] == null)
            {
                return selected;
            }
        }
    }

    private bool Randomization(int chance)
    {
        int randomNumber = Random.Range(0, 100);

        return (randomNumber <= chance);
    }
}
