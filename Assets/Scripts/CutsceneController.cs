using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameObject player;
    public GameObject timerCanvas;

    public GameObject mainCamera;

    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        string level = SceneManager.GetActiveScene().name;
        
        // Activa el parámetro correspondiente al nivel actual
        animator.SetBool("is" + level, true);
    }

    // Update is called once per frame
    public void OnIntroFisnished()
    {
        player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
        mainCamera.SetActive(true);
        gameObject.SetActive(false);
    }
}
