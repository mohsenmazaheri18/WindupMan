using System.Collections;
using IndieMarc.EnemyVision;
using UnityEngine;
using UnityEngine.Serialization;

public class FreezeCutScene : MonoBehaviour
{
    public CharacterMovement characterScript;
    public CharacterFirstGame characterFirstGame;

    // Start is called before the first frame update
    private void Start()
    {
        characterScript.enabled = false;
        characterFirstGame.enabled = true;
        
        StartCoroutine(PlayGame());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(10f);
        characterScript.enabled = true;
        characterFirstGame.enabled = false;
    }
}
