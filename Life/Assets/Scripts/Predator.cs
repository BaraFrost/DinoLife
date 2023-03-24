using UnityEngine;

public class Predator : Animal<Herbivore> {

    protected PredatorManager animalManager;

    protected HerbivoreManager foodManager;

    protected override void Start() {
        base.Start();
        foodManager = FindObjectOfType<HerbivoreManager>();
        animalManager = FindObjectOfType<PredatorManager>();
    }

    protected override Herbivore GetNearestFood(Vector3 position) {
        return foodManager.GetNearestEntity(position);
    }

    protected override void EatFood(Herbivore food) {
        foodManager.DestroyObject(food);
    }

    protected override void Reproduce(Vector3 position) {
        animalManager.CreateEntity(position);
    }

    protected override void DestroyAnimal(SpawnableObject animal) {
        animalManager.DestroyObject(this);
    }
}