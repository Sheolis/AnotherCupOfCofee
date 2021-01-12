using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformScript : MonoBehaviour
{

    [Header("Plateform parameters")]

    [Tooltip("Variable triggering the plateform, allowing it to start moving along his predefined path.")]
    public bool statusTrigger = false;
    [Tooltip("Signal which will trigger the palteform")]
    public SignalController signal;
    [Tooltip("Type : LineRenderer. Path the plateform will follow")]
    public LineRenderer path;
    [Tooltip("Speed of the signal")]
    public float plateformSpeed = 1;

    private Vector3 currentDirection;
    private int checkpoint = 0;
    private int checkpointQuantity;
    private int direction = 1; // Value -1 or 1 depending if the plateform goes forward or backward

    // Start is called before the first frame update
    void Start()
    {
        checkpointQuantity = path.positionCount;
        setCurrentDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( signal.statusArrived )
        {
            if (Vector3.Distance(this.transform.position, path.GetPosition(checkpoint + direction)) > 0.1) // If the Signal is physically close to the node, with a gap of 0.1
            {

                this.transform.Translate(currentDirection * Time.deltaTime * plateformSpeed);

            }
            else
            {
                checkpoint += direction;
                setCurrentDirection();
            }
        }
    }

    private void setCurrentDirection()
    {
        if (checkpoint == checkpointQuantity - 1 || checkpoint + direction == -1)
        {
            direction = - direction;
            currentDirection = (path.GetPosition(checkpoint + direction) - this.transform.position).normalized;
        }
        else
        {
            currentDirection = (path.GetPosition(checkpoint + direction) - this.transform.position).normalized;
        }
    }
}
