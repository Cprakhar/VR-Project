using UnityEngine.Audio;
using UnityEngine;
using Unity.VisualScripting;

[System.Serializable]
public class Sound
{
    public AudioClip audioClip;

    [Range(0f, 10f)]    
    public float volume;
    public bool looped;

    public string name;

    [HideInInspector]
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
