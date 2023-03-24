using UnityEngine;

public class Herbivore : Animal<GreenFood> {

    protected HerbivoreManager animalManager;

    protected FoodManager foodManager;

    protected override void Start() {
        base.Start();
        foodManager = FindObjectOfType<FoodManager>();
        animalManager = FindObjectOfType<HerbivoreManager>();
    }

    protected override GreenFood GetNearestFood(Vector3 position) {
        return foodManager.GetNearestEntity(position);
    }

    protected override void EatFood(GreenFood food) {
        foodManager.DestroyObject(food);
    }

    protected override void Reproduce(Vector3 position) {
        animalManager.CreateEntity(position);
    }

    protected override void DestroyAnimal(SpawnableObject animal) {
        animalManager.DestroyObject(this);
    }
}