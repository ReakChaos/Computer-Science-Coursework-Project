using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSong : MonoBehaviour
{
    // Expose songs array into the Unity Editor whilst keeping it private
    [SerializeField] private AudioClip[] songs;
    // Reference to the AudioSource component
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Makes sure the object stays in-between scene changes
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
        // Plays a random song in the song array
        AudioClip song = songs[UnityEngine.Random.Range(0, songs.Length)];
        myAudioSource.PlayOneShot(song);
    }
}
