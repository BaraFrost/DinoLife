using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FoodManager : MonoBehaviour
{
    private List<EP> food = new List<EP>();
    [SerializeField]
    private Transform bottomRightCorner;
    [SerializeField]
    private Transform upperLeftCorner;
    [SerializeField]
    private int maxFood;
    [SerializeField]
    private EP foodPrefab;
    [SerializeField]
    private float spawnTime;


    void Start()
    {
        GenerateFood();
        StartCoroutine(SpawnFood());
    }


    private void GenerateFood()
    {
        if (food.Count < maxFood)
        {
            var curentFoodCount = food.Count;
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
        CreateFood(new Vector3(x, y, 0));

    }

    private IEnumerator SpawnFood()
    {
        while (true)
        {
            CreateFood();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void CreateFood(Vector3 foodPosition)
    {
        var ep = Instantiate(foodPrefab, new Vector3(foodPosition.x, foodPosition.y, foodPrefab.transform.position.z), Quaternion.identity);
        food.Add(ep);
    }

    public EP GetEP(Transform transform)
    {

        EP result = food[food.Count - 1];
        for (int i = food.Count - 2; i > 0; i--)
        {
            if (Vector3.Distance(transform.position, result.transform.position) > Vector3.Distance(transform.position, food[i].transform.position))
            {
                result = food[i];
            }
        }
        return result;
    }
    public void EatFood(EP ep)
    {
        food.Remove(ep);
        Destroy(ep.gameObject);

    }
    private void Update()
    {

    }


}
