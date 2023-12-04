using System.Collections;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] int _secsToSpawn;
    [SerializeField] Collectable _collectablePrefab;
    
    Collectable _collectable;

    void Start()
    {
        SpawnCollectable();
    }

    void SpawnCollectable()
    {
        _collectable = Instantiate(_collectablePrefab, transform.position, Quaternion.identity);
        _collectable.transform.SetParent(transform);
        _collectable.OnCollected += OnCollectableCollected;
    }

    void OnCollectableCollected()
    {
        _collectable.OnCollected -= OnCollectableCollected;
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(_secsToSpawn);
        SpawnCollectable();
    }
}
