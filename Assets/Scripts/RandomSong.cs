using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSong : MonoBehaviour
{
    // Expose songs array into the Unity Editor whilst keeping it private
    [SerializeField] private AudioClip[] songs;
    // Reference to the AudioSource component
    private AudioSource myAudioSource;
    // Creates variable referenced to this class
    private static RandomSong instance;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>() ;  
    }
    void Awake()
    {
        // If there is no instance of the class, assigns current instance to instance variable
        if (!instance)
        {
            instance = this;
        }
        // Otherwise kill the duplicate
        else
        {
            Destroy(gameObject);
        }
        // Makes sure the object stays in-between scene changes
        DontDestroyOnLoad(gameObject);
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
