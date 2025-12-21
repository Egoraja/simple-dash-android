using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicSwitcher : MonoBehaviour
{
    [Header("FMOD Events")]
    [SerializeField] private EventReference mainMusic_1;
    [SerializeField] private EventReference mainMusic_2;

    private bool isPlayingFirst;
    private EventInstance currentMusic;

    private void Start()
    {
        currentMusic = RuntimeManager.CreateInstance(mainMusic_1);
        currentMusic.start();
        isPlayingFirst = true;
    }

    public void PlayMenuMusic()
    {
        SwitchMusic();
    }

    private void SwitchMusic()
    {
        if (currentMusic.isValid())
        {
            currentMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentMusic.release();
        }
        
        if (isPlayingFirst == true)         
            PlayMusic(mainMusic_2);        
        else        
            PlayMusic(mainMusic_1);
        
        isPlayingFirst = !isPlayingFirst;
    }

    private void PlayMusic(EventReference music)
    {
        currentMusic = RuntimeManager.CreateInstance(music);
        currentMusic.start();
    }

    private void OnDestroy()
    {
        if (currentMusic.isValid())
        {
            currentMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentMusic.release();
        }
    }
}
