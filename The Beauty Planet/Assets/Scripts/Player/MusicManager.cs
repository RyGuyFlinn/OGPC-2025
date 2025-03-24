using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip start;
    public AudioClip middle;
    public AudioClip boss;

    public int currentSong = 1;
    public float fadeDuration = 2f; // Duration for fade in/out

    void Start()
    {
        StartCoroutine(PlayMusicSequence());
    }

    IEnumerator PlayMusicSequence()
    {
        while (true)
        {
            AudioClip selectedClip = GetClipForSong(currentSong);
            if (selectedClip == null) yield break;

            audio.clip = selectedClip;

            for (int i = 0; i < 2; i++) // Play each song twice
            {
                yield return StartCoroutine(FadeIn(audio, fadeDuration)); // Fade in
                audio.Play();
                yield return new WaitForSeconds(audio.clip.length - fadeDuration); // Wait for song duration minus fade out time
                yield return StartCoroutine(FadeOut(audio, fadeDuration)); // Fade out
            }

            yield return new WaitForSeconds(30f); // Wait before switching songs
            currentSong = (currentSong % 3) + 1; // Loop between 1-3
        }
    }

    IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float startVolume = 0f;
        audioSource.volume = startVolume;
        float targetVolume = 1f;

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }

    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float targetVolume = 0f;

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }
        audioSource.volume = targetVolume;
        audioSource.Stop();
    }

    AudioClip GetClipForSong(int songIndex)
    {
        switch (songIndex)
        {
            case 1: return start;
            case 2: return middle;
            case 3: return boss;
            default: return null;
        }
    }
}
