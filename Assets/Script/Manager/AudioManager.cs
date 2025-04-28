
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class manages the different scenes that compose a level
public class AudioManager : MonoBehaviour
{
    public static AudioManager INSTANCE; // Singleton
    public AudioSource source;

    public AudioClip VentanaRota;
    public AudioClip PuertaAbriendo;
    public AudioClip FondoMusica;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INSTANCE = this;
    }
}

