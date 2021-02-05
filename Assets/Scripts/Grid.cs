using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
    // Start is called before the first frame update

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 closestPoint = new Vector3((float)xCount,(float)yCount,(float)zCount);
        closestPoint += transform.position;
        return closestPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 40; x += size)
        {
            for (float z = 0; z < 40; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, .1f);
            } 
        }
    }
}
