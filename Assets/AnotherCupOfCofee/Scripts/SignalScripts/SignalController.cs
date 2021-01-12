using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    [Header("Signal parameters")]

    [Tooltip("Variable triggering the signal, allowing it to start moving towards his target.")]
    public bool statusTrigger = false;
    [Tooltip("Give the information about is the signal arrived at destination or not.")]
    public bool statusArrived = false;
    [Tooltip("Type : LineRenderer. Path the signal will follow")]
    public LineRenderer path;
    [Tooltip("Speed of the signal")]
    public float signalSpeed = 1;


    private Vector3 currentDirection;
    private int checkpoint;
    private int checkpointQuantity;

    // Start is called before the first frame update
    void Start()
    {
        checkpointQuantity = path.positionCount;
        checkpoint = 0;
        setCurrentDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (statusTrigger && !statusArrived)
        {
            if (Vector3.Distance(this.transform.position, path.GetPosition(checkpoint + 1)) > 0.1) // If the Signal is physically close to the node, with a gap of 0.1
            {

                this.transform.Translate(currentDirection * Time.deltaTime * signalSpeed);

            }
            else
            {
                checkpoint += 1;
                setCurrentDirection();
            }
        }
    }

    private void setCurrentDirection()
    {
        if (checkpoint == checkpointQuantity -1)
        {
            statusArrived = true;
        }
        else
        {
            currentDirection = (path.GetPosition(checkpoint + 1) - this.transform.position).normalized;
        }
    }
}

