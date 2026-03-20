using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFX : MonoBehaviour
{
    [SerializeField]
    AudioSource soundSource;
    //Play the audio once
   public void playSFX(AudioClip audio, Transform transform, float volume)
    {
        AudioSource game = Instantiate(soundSource,transform);
        game.clip = audio;
        game.Play();
        float duration = game.clip.length;
        Destroy(game.gameObject,duration);
    }
}
