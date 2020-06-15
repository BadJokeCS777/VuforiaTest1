using System.Collections.Generic;
using UnityEngine;

public class MarksTracker : MonoBehaviour
{
    [SerializeField] private GameObject _wall;

    public List<GameObject> Targets;

    private void Start()
    {
        Targets = new List<GameObject>();
    }

    public void OnTargetFound()
    {
        if (Targets.Count > 1)
        {
            int parent1 = 0;
            int parent2 = 0;
            
            FindNearestTargets(ref parent1, ref parent2);
            
            GameObject wall = Instantiate(_wall);
            wall.GetComponent<WallRenderer>().Parent1 = Targets[parent1];
            wall.GetComponent<WallRenderer>().Parent2 = Targets[parent2];
        }
    }

    private void FindNearestTargets(ref int parent1, ref int parent2)
    {
        float distance = float.MaxValue;

        for (int i = 0; i < Targets.Count - 1; i++)
            for (int j = i + 1; j < Targets.Count; j++)
            {
                float currentDistance = Vector3.Distance(Targets[i].transform.position, Targets[j].transform.position);

                if (distance > currentDistance && currentDistance > 0)
                {
                    distance = currentDistance;
                    parent1 = i;
                    parent2 = j;
                }
            }
    }

    public void OnTargetLost()
    {
        
    }
}
