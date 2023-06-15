using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[][] paths;
    public Transform[] pathPrefabs;

    void Awake()
    {
        if (pathPrefabs != null)
        {
            paths = new Transform[pathPrefabs.Length][];

            for (int i = 0; i < pathPrefabs.Length; i++)
            {
                if (pathPrefabs[i] != null)
                {
                    Transform[] waypoints = pathPrefabs[i].GetComponentsInChildren<Transform>();
                    paths[i] = new Transform[waypoints.Length - 1];
                    for (int j = 1; j < waypoints.Length; j++)
                    {
                        paths[i][j - 1] = waypoints[j];
                    }
                }
              
            }
        }
       
    }

}
