using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTime : MonoBehaviour
{
    public GameObject timeField;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        timeField.GetComponent<Controllers>().timeControls = true;
    }
}
