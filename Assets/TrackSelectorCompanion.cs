using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrackSelectorCompanion : MonoBehaviour
{
    public MusicManager musicManager;
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        MusicManager.TrackChanged += UpdateText;
    }

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        text.text = musicManager.GetCurrentTrackName();
    }

    public void OnPress(bool forward)
    {
        int increment = forward? 1:-1;
        int ctid = musicManager.current_trackID-1;
        int length = musicManager.tracks.Length;

        ctid += increment;
        if (ctid < 0) ctid = length-1;
        ctid %= length;

        Debug.Log("track id being passed to the mm: " + ctid);

        musicManager.ChangeTracks(ctid+1);
        UpdateText();
    }
}
