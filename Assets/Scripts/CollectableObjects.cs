using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{

    private int targetIndex;

    public void SetTargetIndex(int index)
    {
        targetIndex = index;
    }

    public int GetTargetIndex()
    {
        return targetIndex;
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
