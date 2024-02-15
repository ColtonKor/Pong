using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource audioGoal;
    // public AudioSource audioPaddle;
    public AudioSource audioWall;
    public CameraShake cameraShake;
    public GameObject scorePower;
    public GameObject sizePower;
    public GameManager gameManager;
    // private float sound = 1f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        TrailRenderer trail = GetComponent<TrailRenderer>();
        if(other.gameObject.CompareTag("Goal")){
            gameManager.ScoreUpdate(1);
            scorePower.gameObject.SetActive(false);
            sizePower.gameObject.SetActive(false);
            trail.startWidth = 0.5f;
            trail.endWidth = 0.0f;
            audioGoal.Play();
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            scorePower.transform.position = new Vector3(Random.Range(-8f, 8f), 0.3f, Random.Range(-5f, 5f));
            sizePower.transform.position = new Vector3(Random.Range(-8f, 8f), 0.3f, Random.Range(-5f, 5f));
            int location = Random.Range(0,5);
            if(location == 1){
                scorePower.gameObject.SetActive(true);
            } else if (location == 2) {
                sizePower.gameObject.SetActive(true);
            } else if (location == 3){
                sizePower.gameObject.SetActive(true);
                scorePower.gameObject.SetActive(true);
            }

        } else if (other.gameObject.CompareTag("Size")) {
            trail.startWidth = 0.2f;
            trail.endWidth = 0.0f;
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            other.gameObject.SetActive(false);
        } else if (other.gameObject.CompareTag("Score")){
            other.gameObject.SetActive(false);
            gameManager.ScoreUpdate(3);
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Wall")){
            StartCoroutine(cameraShake.Shake(0.2f, 0.1f));
            audioWall.Play();
        } 
    }
}
