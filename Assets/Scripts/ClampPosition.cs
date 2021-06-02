using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clamps position of a gameobject
/// </summary>
public class ClampPosition : MonoBehaviour
{
    
    [System.Serializable, System.Flags]
    public enum PositionFlags {
        x = 1,
        y = 2,
        z = 4
    }

    public PositionFlags clampedPos;

    private Vector3 startingPositions; 
    
    // Start is called before the first frame update
    void Start()
    {

        startingPositions = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var newPos = new Vector3(
            (clampedPos & PositionFlags.x) == PositionFlags.x ? startingPositions.x : position.x,
            (clampedPos & PositionFlags.y) == PositionFlags.y ? startingPositions.y : position.y,
            (clampedPos & PositionFlags.z) == PositionFlags.z ? startingPositions.z : position.z
            );
        transform.position = newPos;
    }
}
