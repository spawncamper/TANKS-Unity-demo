﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject persistentObjectPrefab;

    static bool initialSpawn = false;    // hasSpawned
    int sceneIndex;

    private void Start()
    {
        PersistentObjectSpawner persistentObjectSpawner = FindObjectOfType<PersistentObjectSpawner>();
        if (persistentObjectSpawner == null)
            DontDestroyOnLoad(this);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(sceneIndex);
    }

    private void Awake()
    {
        if (initialSpawn == true)
        {
            return;
        }
        else if (initialSpawn == false && sceneIndex > 0)
        {
            initialSpawn = true;
            SpawnPersistentObjects();
        }
    }

    void SpawnPersistentObjects()
    {
        GameObject PersistenObjects = Instantiate(persistentObjectPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        DontDestroyOnLoad(PersistenObjects);
    }
}