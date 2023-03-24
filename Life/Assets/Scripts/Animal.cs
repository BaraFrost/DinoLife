using System.Collections;
using UnityEngine;

public abstract class Animal<F> : SpawnableObject where F : SpawnableObject {

    private Rigidbody2D rigidbody;

    private float _health;

    protected float health {
        get { return _health; }
        set {
            if (value < 0) {
                Destroy();
            } else if (value > healthToReproduction) {
                Reproduce();
            } else {
                _health = value;
            }
        }
    }

    protected F food;

    [Header("Health")]
    [SerializeField]
    private float startHealth;

    [Header("Health")]
    [SerializeField]
    private float healthRecovery = 4;

    [Header("Health")]
    [SerializeField]
    private float healthToReproduction;

    [SerializeField]
    private float healthAfterReproduction;

    [SerializeField]
    private float timeToConsumeHealh;

    [SerializeField]
    protected float speed;

    [SerializeField]
    private float extraSpeed;

    [SerializeField]
    private float healthForAcceleration;

    protected virtual void Start() {
        _health = startHealth;
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ConsumeHealth());
    }

    protected virtual IEnumerator ConsumeHealth() {
        while (true) {
            health--;
            yield return new WaitForSeconds(timeToConsumeHealh);
        }
    }

    void Update() {

        food = GetNearestFood(transform.position);
        if (food == null) {
            Move(Vector3.zero, 0);
            return;
        }

        float curentSpeed = health < healthForAcceleration ? extraSpeed : speed;
        Move(food.transform.position, curentSpeed);
    }

    protected abstract F GetNearestFood(Vector3 position);
    protected abstract void EatFood(F food);
    protected abstract void Reproduce(Vector3 position);
    protected abstract void DestroyAnimal(SpawnableObject animal);

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<F>(out var food)) {
            Feed();
            EatFood(food);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<F>(out var food)) {
            Feed();
            EatFood(food);
        }
    }

    protected void Move(Vector3 target, float speed) {
        rigidbody.velocity = (-transform.position + target).normalized * speed;
        Rotate(target);
    }

    private void Rotate(Vector3 target) {
        if (transform.position.x > target.x) {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        } else if (transform.position.x < target.x) {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    protected virtual void Feed() {
        health += healthRecovery;
    }

    protected virtual void Reproduce() {
        health = healthAfterReproduction;
        Reproduce(gameObject.transform.position);
    }

    protected virtual void Destroy() {
        DestroyAnimal(this);
    }
}
