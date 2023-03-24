using UnityEngine;

[RequireComponent(typeof(FoodManager))]
public class FoodSpawn : MonoBehaviour
{
    public Camera camera;
    private FoodManager manager;

    private void Start()
    {
        manager = GetComponent<FoodManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            manager.CreateEntity(camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward);
        }
    }

}
