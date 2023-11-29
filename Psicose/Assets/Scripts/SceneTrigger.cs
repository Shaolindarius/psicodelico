using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string SceneToLoad; // Nome da cena para carregar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {    
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

