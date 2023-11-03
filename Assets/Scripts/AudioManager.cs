using System;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public Sound[] sounds;
	public GameObject player;
	public TextMeshProUGUI textSpeak;
	void Start ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play (string sound)
	{
		
		Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Play();
 
    }

	public void StartSpeak()
	{
		player.GetComponent<Animator>().enabled = true;
		int p = UnityEngine.Random.Range(0, sounds.Length);
        sounds[p].source.Play();
		textSpeak.text = sounds[p].text;
		Invoke("StopSpeak", sounds[p].source.clip.length);
    }

	public void StopSpeak()
	{
        player.GetComponent<Animator>().enabled = false;
    }
}
