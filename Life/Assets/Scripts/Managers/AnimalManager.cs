using System.Linq;

public abstract class AnimalManager<T> : Spawner<T> where T : SpawnableObject {
    private void Start() {
        createdEntity = FindObjectsOfType<T>().ToList();
    }
}
