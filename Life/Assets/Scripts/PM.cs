using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PM : MonoBehaviour
{

    public EP food;
    public float speed;
    public float health = 100;
    private FoodManager foodManager;
    public float pH = 4;
    public float extraSpeed;
    public Rigidbody2D rigidbody;
    void Start()
    {
        foodManager = FindObjectOfType<FoodManager>();
        rigidbody = GetComponent<Rigidbody2D>();
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
        
        rigidbody.velocity = (- transform.position + food.transform.position).normalized * speed;
        //transform.position = Vector2.MoveTowards(transform.position, food.transform.position, curentSpeed * Time.deltaTime);

        if (transform.position.x > food.transform.position.x) 
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (transform.position.x < food.transform.position.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EP>(out var food))
        {
            foodManager.EatFood(food);
            health += pH;

        }
    }
    
}