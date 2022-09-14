using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{

    private int children;
    [SerializeField] private int minChildren;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private Vector2Int range;
    [SerializeField] private int waitFramesForUpdate;
    private int framesToNextUpdate;

    void Update()
    {
        if (framesToNextUpdate == 0)
        {
            children = CountChildren();
            if (children < minChildren)
            {
                CreateTree();
            }
            framesToNextUpdate = waitFramesForUpdate;
        }
        else
        {
            framesToNextUpdate--;
        }
    }

    private int CountChildren()
    {
        return transform.childCount;
    }

    public void CreateTree()
    {
        // GameObject newtree = treePrefab;
        GameObject newtree = Instantiate(treePrefab, gameObject.transform);

        Vector3 position = newtree.transform.position;
        position.x += Random.Range(range.x, range.y);
        position.z += Random.Range(range.x, range.y);
        newtree.transform.position = position;

        Collider[] collitions = Physics.OverlapSphere(newtree.GetComponent<Renderer>().bounds.center, newtree.GetComponent<Renderer>().bounds.extents.y);

        if (collitions.Length > 1) Destroy(newtree);
        // Debug.Log(newtree.transform.position);
        // foreach (Collider collider in collitions)
        // {
        //     Debug.Log(collider.name);
        // }
    }
}
