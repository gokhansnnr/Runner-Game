using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HitBarrier : MonoBehaviour
{
    private int left;
    public GameObject hit;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        left = hit.GetComponent<Controllers>().left;
        left -= 1;
        hit.GetComponent<Controllers>().left = left;
        //leftText.text = "Left: " + left;
    }
}
