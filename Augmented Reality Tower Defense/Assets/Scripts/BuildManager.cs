using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than one Builder in scene!");
            return;
        }
        Instance = this;
    }
    public GameObject standardTurretPrefab;

    void Start()
    {
        turrettoBuild = standardTurretPrefab;
    }

    private GameObject turrettoBuild;

    public GameObject getTurrettoBuild()
    {
        return turrettoBuild;
    }
}
