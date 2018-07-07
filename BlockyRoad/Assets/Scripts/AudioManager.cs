using UnityEngine;

[System.Serializable]

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public static AudioManager instance;
    private static bool created = false;
    public ScriptableAudio[] scriptableAudio;

    private AudioSource Source;
    private AudioClip Clip;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }


        if (!created)
        {
            created = true;
            Debug.Log("Awake: " + this.gameObject);

        }
    }

    void Start()
    {
        for (int i = 0; i < scriptableAudio.Length; i++)
        {
            GameObject go = new GameObject("Sound" + scriptableAudio[i].name);
            go.transform.SetParent(this.transform);
           scriptableAudio[i].SetSource (go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < scriptableAudio.Length; i++)
        {
            if (scriptableAudio[i].name == name)
            {
                scriptableAudio[i].Play();
               return;
            }
        }
        Debug.LogWarning("Sound not found," + name);
    }
}
/*
 * Container for SciptableAudio
 * On Wake create AudioManger 
 * Collect ScriptableAudio data and create named audiosource gameobjects 
 * Search for Sounds name and play
 */
