using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoodManager))]
public class FoodSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Camera camera;
    private FoodManager manager;

    private void Start()
    {
        manager= GetComponent<FoodManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.CreateFood(camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward);
        }
    }

}
