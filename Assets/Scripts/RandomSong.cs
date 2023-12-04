using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSong : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        myAudioSource = GetComponent<AudioSource>() ;
    }
    // Update is called once per frame
    void Update()
    {
        if (myAudioSource.isPlaying == false)
        {
            playSong();
        }

    }
    void playSong()
    {
        AudioClip song = songs[UnityEngine.Random.Range(0, songs.Length)];
        myAudioSource.PlayOneShot(song);
    }
}
