using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    /// <summary>
    /// This function is triggered once an object with the tag "breakable" enters the collision. 
    /// ACTION: Executes "Smash" funtion on Component "Pod".
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<Pod>().Smash();
        }
    }
}
