using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour {

    public static SpawnersManager _instance;

    public static SpawnersManager Instance {
        get {
            if (_instance == null) {
                var gameObject = new GameObject(nameof(SpawnersManager));
                _instance = gameObject.AddComponent<SpawnersManager>();
                _instance.Init();
            }
            return _instance;
        }
    }

    private Dictionary<Type, UnityEngine.Object> _spawners;

    public Dictionary<Type, UnityEngine.Object> Spawners => _spawners;

    protected void Init() {
        _spawners = new Dictionary<Type, UnityEngine.Object>();
        _spawners.Add(typeof(PredatorManager), gameObject.AddComponent<PredatorManager>());
        _spawners.Add(typeof(PredatorManager), gameObject.AddComponent<PredatorManager>());
        _spawners.Add(typeof(PredatorManager), gameObject.AddComponent<PredatorManager>());
        _spawners.Add(typeof(PredatorManager), gameObject.AddComponent<PredatorManager>());
    }

}
