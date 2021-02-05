using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    private Grid grid;
    public GameObject basicHouseLvl1;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Ground")
                {
                    PlaceNear(hit.point);
                }
                else
                {
                    print("Already Has Something!" + hit.collider.name);
                }
            }
        }
    }

    private void PlaceNear(Vector3 nearestPoint)
    {
        var finalPos = grid.GetNearestPointOnGrid(nearestPoint);
        //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPos;
        GameObject go = Instantiate(basicHouseLvl1);
        go.transform.position = finalPos;
    }

    private void Place()
    {

    }
}
