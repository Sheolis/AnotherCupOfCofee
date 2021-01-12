using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour
{
    [Header("Lever parameters")]

    [Tooltip("Type : BoxCollide, zone where the lever will be pullable by the player.")]
    public BoxCollider pullZone;
    [Tooltip("Type : bool. Is true if the player pulled the lever.")]
    public bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
