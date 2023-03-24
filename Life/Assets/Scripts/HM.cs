using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HÛM : MonoBehaviour
{

    public EP food;
    public float speed;
    public float health = 100;
    private FoodManager foodManager;
    public float pH = 4;
    public float extraSpeed;

    void Start()
    {
        foodManager = FindObjectOfType<FoodManager>();
    }

    void Update()
    {
        float curentSpeed = health < 75 ? extraSpeed : speed;
        health -= Time.deltaTime * 2;
        food = foodManager.GetEP(transform);
        if (food == null)
        {
            return;
        }


        transform.position = Vector2.MoveTowards(transform.position, food.transform.position, curentSpeed * Time.deltaTime);

        if (health > 150)
        {
            health -= 100;
            Instantiate(gameObject);
            health += 50;
        }
        if (health < 1)
        {
            Destroy(this.gameObject);
        }


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.TryGetComponent<EP>(out var food))
        {
            foodManager.EatFood(food);
            health += pH;

        }

    }
}