using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

//this function is where the names of our sounds will go under
//it will be the name of the sound followed by a comma
//bascially you add the ENUM name and then assosiate a number with it so then you could call the number or the string you assossicate with the enum later
public enum SoundType
{
    //example format below
    //CLICK,
    //SOLVED,
    BIRDFLAP,
    DESCEND,
    DING,
    DOOR,
    IMPACT,
    PIG,
    REAPER,
    SNAPPERGROW,
    SNAPPERSNAP,
    STEP,
    SUMMON,
}

//we use this to get random varing sound volumes
//this whole thing is not needed but ill leave it here in case you guys have an idea for it
public struct Range
{
    private readonly float min;
    private readonly float max;

    public Range(float min,float max)
    {
        this.min = min;
        this.max = max;
    }

    public float GetRandValue()
    {
        return Random.Range(min,max);
    }
}


//this main function we use from this is the soundCollection that  is used to load all the audio files under Audio/Resources file path
public class SoundCollection {
    private AudioClip[] clips;

    public SoundCollection(params string[] audioNames){
        clips = new AudioClip[audioNames.Length];
        for(int i = 0; i < clips.Length; i++){
            clips[i] = Resources.Load(audioNames[i]) as AudioClip;
            if (clips[i] == null){
                //if this is throw the file is probably not in the right place or there is a typo
                Debug.LogWarning($"count find clip {audioNames[i]}");
            }
        }
    
    }

    public AudioClip GetRandClip(){
        if(clips.Length == 0){
            Debug.LogWarning("no clips found");
            return null;
        }
        else if(clips.Length == 1){
            return clips[0];
        }
        else{
            return clips[Random.Range(0, clips.Length)];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class soundManager : MonoBehaviour{
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;

    public static soundManager Instance { get; private set; }

    private void Awake(){
        Instance = this;
    }
    public void Start(){
        audioSrc = GetComponent<AudioSource>();
        sounds = new()
        {
            //this line should be repeated and the file path should be in the new() with the filename included in the path. it Starts in the Resources so if your file is already there just put the name
            {SoundType.BIRDFLAP, new("birdflap") },
            {SoundType.DESCEND, new("descend") },
            {SoundType.DING, new("ding") },
            {SoundType.DOOR, new("door") },
            {SoundType.IMPACT, new("impact") },
            {SoundType.PIG, new("pig") },
            {SoundType.REAPER, new("reaper") },
            {SoundType.SNAPPERGROW, new("snappergrow") },
            {SoundType.SNAPPERSNAP, new("snappersnap") },
            {SoundType.STEP, new("step") },
            {SoundType.SUMMON, new("summon") }
        };
    }
     



    //these are the the functions you call to actually play your sound, you can use play(int) or play(str) where you can specify your sounds enum value or call it by file name
    public void Play(SoundType type, AudioSource audioSrc = null){
        if (sounds.ContainsKey(type)){
            if(audioSrc == null ){
                //if (!this.audioSrc.isPlaying)
                //{
                    this.audioSrc.clip = sounds[type].GetRandClip();
                    this.audioSrc.Play();
                //}
            }
            else{
                    print("playsound");
                    audioSrc.clip = sounds[type].GetRandClip();
                    audioSrc.Play();
                
            }
        }   
    }
    public void Play(string type,AudioSource audioSrc){
       
            SoundType soundType = Enum.Parse<SoundType>(type, true);
            Play(soundType, audioSrc);
        
    }
    public void Play(string type){
        Play(type, audioSrc);
    }
    public void Play(int type){
        Play((SoundType)type, audioSrc);
    }
}   
