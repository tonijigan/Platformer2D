using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Transform _setPoint;
    [SerializeField] private Coin _coin;

    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_setPoint.childCount];

        for (int i = 0; i < _setPoint.childCount; i++)
        {
            _points[i] = _setPoint.GetChild(i);
        }
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i]);
        }
    }
}
