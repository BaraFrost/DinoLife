using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Spawner<T> : MonoBehaviour where T : SpawnableObject {

    protected List<T> createdEntity = new List<T>();

    [SerializeField]
    protected T entityPrefab;

    public void CreateEntity(Vector3 foodPosition) {
        var entity = Instantiate(entityPrefab, new Vector3(foodPosition.x, foodPosition.y, entityPrefab.transform.position.z), Quaternion.identity);
        createdEntity.Add(entity);
    }

    public T GetNearestEntity(Vector3 position) {
        if(createdEntity.Count == 0) {
            return null;
        }
        T result = createdEntity[createdEntity.Count - 1];
        for (int i = createdEntity.Count - 2; i > 0; i--) {
            if (Vector3.Distance(position, result.transform.position) > Vector3.Distance(position, createdEntity[i].transform.position)) {
                result = createdEntity[i];
            }
        }
        return result;
    }

    public void DestroyObject(T entity) {
        createdEntity.Remove(entity);
        Destroy(entity.gameObject);
    }
}
