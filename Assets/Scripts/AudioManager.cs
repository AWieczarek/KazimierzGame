using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Color carColor;
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
             s.source = gameObject.AddComponent<AudioSource>();
             s.source.outputAudioMixerGroup = s.audioMixer;
             s.source.clip = s.clip;
             s.source.volume = s.volume;
             s.source.pitch = s.pitch;
             s.source.loop = s.loop;
        }
    }

    private void Start() 
    {
        Play("Theme");
        Play("Engine");
        if (PlayerPrefs.GetString("CarColor") == "")
		{
            PlayerPrefs.SetString("CarColor", carColor.ToString());

        }
        var storedColorAsString = "#" + PlayerPrefs.GetString("CarColor");
        ColorUtility.TryParseHtmlString(storedColorAsString, out carColor);
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
