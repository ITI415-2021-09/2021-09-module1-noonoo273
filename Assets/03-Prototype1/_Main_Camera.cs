using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Main_Camera : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;

    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]

    public float camPosZ;

    // Start is called before the first frame update
    void Awake()
    {
        camPosZ = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (POI == null) return;

        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;

            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camPosZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }
}
