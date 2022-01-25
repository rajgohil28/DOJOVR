using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastVoiceOver : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.transform.tag == "Posters")
                {
                    AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
                    for (int i = 0; i < audios.Length; i++)
                    {
                        audios[i].Stop();
                    }
                    Debug.Log("Hit Poster" + hit.transform.gameObject.name);
                    AudioSource audio = hit.transform.gameObject.GetComponent<AudioSource>();
                    Debug.Log("Audio Source Found");
                    if (audio.isPlaying == false)
                    {
                        audio.Play();
                    }
                    else
                    {
                        audio.Stop();
                    }

                }
                else if (hit.transform.name == "Main Room")
                    SceneManager.LoadScene(0);
                else if (hit.transform.name == "Company Overview")
                    SceneManager.LoadScene(1);
                else if (hit.transform.name == "Safety DOJO")
                    SceneManager.LoadScene(2);
                else if (hit.transform.name == "5 Sense DOJO")
                    SceneManager.LoadScene(3);
                else if (hit.transform.name == "Product DOJO")
                    SceneManager.LoadScene(4);
                else if (hit.transform.name == "Process DOJO")
                    SceneManager.LoadScene(5);
                else if (hit.transform.name == "Quality DOJO")
                    SceneManager.LoadScene(6);
                else if (hit.transform.name == "Production Knowledge")
                    SceneManager.LoadScene(7);
                else if (hit.transform.name == "Maintenance DOJO")
                    SceneManager.LoadScene(8);
                else
                    Debug.Log(hit.transform.name);
            }
        }
        
    }
}
