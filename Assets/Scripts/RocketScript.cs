using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour {

    public int playerArtQuantity = 0;
    public AudioSource audioSource;
    public AudioClip currentAmbient;
    public AudioClip currentMessage;
    public AudioClip endMusic;
    public float volume = 0.7f;
    private bool played;
    public string levelToLoad;

    DialogueSystem DS;

    void Start()
    {
        DS = GameObject.Find("Rockets").GetComponent<DialogueSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbeble")
        {
            audioSource.PlayOneShot(currentAmbient, volume);
            playerArtQuantity += 1; 
            Destroy(col.gameObject);

            
                
            

            if (playerArtQuantity == 1)
            {
                DS.dialogueText = new string[1];
                DS.dialogueText[0] = "Отлчино, первый есть! Ещё всего два и мы сможем лететь домой!";
                
            }

            if (playerArtQuantity == 2)
            {
                DS.dialogueText = new string[1];
                DS.dialogueText[0] = "Ещё один?! Шикарно! Дело за малым. Остался последний. Поднажми ещё немного! Мы приудем домой героями!";
                
            }

            if (playerArtQuantity == 3)
            {
                DS.dialogueText = new string[4];
                DS.dialogueText[0] = "Великолепно! Они все у нас. Наконец-то, мы можем отпправляться домой. Больше не придётся с болью смотреть на окружающую тебя пустошь! Земля снова станет великой.";
                DS.dialogueText[1] = "А когда она станет великой снова откроют Станкин и мы с тобой опять сможем туда ходить!";
                DS.dialogueText[2] = "Ты готов? За станкин!!!";
                DS.dialogueText[3] = "???";


                
            }

            

            StartCoroutine(Example());
            

        }
    }

    void Update()
    {
        if (DS.i == 3 && playerArtQuantity == 3 && !played)
        {

            SceneManager.LoadScene(levelToLoad);
            SceneManager.UnloadSceneAsync("main");

            played = !played;
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(1.5f);
        audioSource.PlayOneShot(currentMessage, 1f);
        print(Time.time);
    }
}
