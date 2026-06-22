using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndieMarc.EnemyVision
{
    /// <summary>
    /// Demo script on how to link animations and use Enemy events
    /// </summary>

    [RequireComponent(typeof(EnemyVision))]
    public class EnemyDemo : MonoBehaviour
    {
        public GameObject exclama_prefab;
        public GameObject death_fx_prefab;

        private EnemyVision enemy;
        private Animator animator;

        public GameObject LosePanel;
        public GameObject soundAlarm;

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            enemy = GetComponent<EnemyVision>();
            enemy.onDeath += OnDeath;
            enemy.onAlert += OnAlert;
            enemy.onSeeTarget += OnSeen;
            enemy.onDetectTarget += OnDetect;
            enemy.onTouchTarget += OnTouch;

        }

        void Update()
        {
            if (animator != null && enemy.GetEnemy() != null)
            {
                animator.SetBool("Move",
                    enemy.GetEnemy().GetMove().magnitude > 0.5f || enemy.GetEnemy().GetRotationVelocity() > 10f);
            }
        }

        //Can be either because seen or heard noise
        private void OnAlert(Vector3 target)
        {
            if (exclama_prefab != null)
                Instantiate(exclama_prefab, transform.position + Vector3.up * 4f, Quaternion.identity);
            if (animator != null)
                animator.Play("Zombie_Idle");
                
        }

        private void OnSeen(VisionTarget target, int distance)
        {
            //Add code for when target get seen and enemy get alerted, 0=touch, 1=near, 2=far, 3=other
            
            if (distance==1)
            {
                soundAlarm.SetActive(true);
                StartCoroutine(WaitToReload());
                LosePanel.SetActive(true);
                PlayerPrefs.SetInt("GameLose", 1);
            }
        }

        private void OnDetect(VisionTarget target, int distance)
        {
            //Add code for when the enemy detect you as a threat (and start chasing), 0=touch, 1=near, 2=far, 3=other
            if (distance == 1.5f)
            {
                soundAlarm.SetActive(true);
                StartCoroutine(WaitToReload());
                LosePanel.SetActive(true);
                PlayerPrefs.SetInt("GameLose", 1);
            }
        }
        private IEnumerator WaitToReload()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Game");
        }
        

        private void OnTouch(VisionTarget target)
        {
            //Add code for when you get caughts
            
        }

        private void OnDeath()
        {
            if (death_fx_prefab)
                Instantiate(death_fx_prefab, transform.position + Vector3.up * 0.5f,
                    death_fx_prefab.transform.rotation);
        }

    }
}
