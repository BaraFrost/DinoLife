using System.Collections;
using UnityEngine;

public class FoodManager : Spawner<GreenFood>
{
    [SerializeField]
    private Transform bottomRightCorner;
    [SerializeField]
    private Transform upperLeftCorner;
    [SerializeField]
    private int maxFood;
    [SerializeField]
    private float spawnTime;

    void Start()
    {
        GenerateFood();
        StartCoroutine(SpawnFood());
    }

    private void GenerateFood()
    {
        if (createdEntity.Count < maxFood)
        {
            var curentFoodCount = createdEntity.Count;
            for (int i = 0; i < maxFood - curentFoodCount; i++)
            {
                CreateFood();
            }
        }
    }

    private void CreateFood()
    {
        var x = Random.Range(upperLeftCorner.position.x, bottomRightCorner.position.x);
        var y = Random.Range(upperLeftCorner.position.y, bottomRightCorner.position.y);
        CreateEntity(new Vector3(x, y, 0));
    }

    private IEnumerator SpawnFood()
    {
        while (true)
        {
            CreateFood();
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
