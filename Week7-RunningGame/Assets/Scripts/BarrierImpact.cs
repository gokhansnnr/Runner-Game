using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrierImpact : MonoBehaviour
{
    private int score;
    private int point;
    public GameObject impact;

    private void OnTriggerEnter(Collider other)
    {
        score = impact.GetComponent<Controllers>().score;
        point = impact.GetComponent<Controllers>().point;
        score += point;
        impact.GetComponent<Controllers>().score = score;
    }
}
