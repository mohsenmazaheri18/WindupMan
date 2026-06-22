using System.Collections;
using System.Collections.Generic;
using IndieMarc.EnemyVision;
using UnityEngine;
using UnityEngine.AI;

public class TriggerEnemyLaser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            gameObject.transform.GetComponentInParent<Enemy>().enabled = false;
            gameObject.transform.GetComponentInParent<NavMeshAgent>().enabled = false;
            gameObject.transform.GetComponentInParent<EnemyDemo>().enabled = false;
            gameObject.transform.GetComponentInParent<Animator>().Play("Idle");
            gameObject.transform.GetComponentInParent<EnemyVision>().enabled = false;
        }
    }
}
