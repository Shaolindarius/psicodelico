using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProximaFase();
        
    }

    private void ProximaFase()
    {
        SceneManager.LoadScene(this.sceneName);
    }


}

