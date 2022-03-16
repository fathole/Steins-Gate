using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class MusicPlayer : MonoBehaviour
{
    public Text txtTime, txtSongName, txtRandom;
    public AudioSource audioSource;
    public int CurrentSongIndex; //get the index of song in list
    public List<AudioClip> musicList = new List<AudioClip>();
    private List<AudioClip> SelectList = new List<AudioClip>();
    public List<int> PlayedHistory = new List<int>();//load by song index in music list
    public Dropdown OrderByDropDown;
    private List<string> OrderByList = new List<string> { "歌名順序", "歌名倒序", "時間順序", "時間倒序" };
    private bool PlayRandom, PlayLoop, HideController;
    public Slider progressBar;
    private int playTime, clipLength;
    public Animator btnLoopAnimator, ControllerAnimator;
    public Text txtShowOrHideButton;
    public GameObject SelectContent;
    public GameObject SelectMusicBoxPrefab;
    public GameObject SelectSongPanel;
    public InputField inputFieldSearch;

    private void Start()
    {
        foreach (AudioClip audioClip in Resources.LoadAll("Audio"))
        {
            musicList.Add(audioClip);
        }
    }

    private void Update()
    {
        if (audioSource.clip != null)
        {
            playTime = (int)audioSource.time;
            UpdateTime();
            if (playTime >= (int)audioSource.clip.length)
            {
                if (PlayLoop)
                {
                    audioSource.time = 0;
                }
                else
                {
                    btnNext();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(GameObject.FindObjectOfType<LoadingSystem>().LoadScene(0));
        }
    }

    private void UpdateTime()
    {
        int minutes = (playTime / 60) % 60;
        int seconds = playTime % 60;
        int fullMinutes = (clipLength / 60) % 60;
        int fullSeconds = clipLength % 60;
        txtTime.text = minutes + ":" + seconds.ToString("D2") + "/" + fullMinutes + ":" + fullSeconds.ToString("D2");
        progressBar.maxValue = clipLength;
        progressBar.value = playTime;
    }

    private void UpdateName()
    {
        txtSongName.text = audioSource.clip.name;
        clipLength = (int)audioSource.clip.length;
    }

    public void UpdateProgressBar()
    {
        audioSource.time = progressBar.value;
    }

    public void btnPrevious()
    {
        if (PlayedHistory.Count > 1)
        {
            audioSource.time = 0;
            PlayedHistory.RemoveAt(PlayedHistory.Count - 1);
            audioSource.clip = musicList[PlayedHistory[PlayedHistory.Count - 1]];
            CurrentSongIndex = PlayedHistory[PlayedHistory.Count - 1];
            audioSource.Play();
            UpdateName();
        }
        else
        {
            Debug.Log("No Previous Song");
        }
    }

    public void btnNext()
    {
        audioSource.time = 0;
        if (PlayRandom)
        {
            CurrentSongIndex = Random.Range(0, musicList.Count);
        }
        else
        {
            CurrentSongIndex++;
            if (CurrentSongIndex > musicList.Count - 1)
            {
                CurrentSongIndex = 0;
            }
        }
        PlayedHistory.Add(CurrentSongIndex);
        audioSource.clip = musicList[CurrentSongIndex];
        audioSource.Play();
        UpdateName();
    }

    public void btnPause()
    {
        audioSource.Pause();
    }

    public void btnPlay()
    {
        if (PlayRandom)
        {
            CurrentSongIndex = Random.Range(0, musicList.Count);
        }
        else
        {
            if (audioSource.clip == null)
            {
                CurrentSongIndex = 0;
            }
        }
        if (audioSource.clip == null)
        {
            audioSource.clip = musicList[CurrentSongIndex];
            PlayedHistory.Add(CurrentSongIndex);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();

        }
        else
        {
            Debug.Log("Playing");
        }
        UpdateName();
    }

    public void btnRandom()
    {
        if (!PlayRandom)
        {
            PlayRandom = true;
            txtRandom.color = Color.red;
        }
        else
        {
            PlayRandom = false;
            txtRandom.color = new Color32(50, 50, 50, 255);
        }
    }

    public void btnLoop()
    {
        if (PlayLoop)
        {
            PlayLoop = false;
            btnLoopAnimator.SetBool("Loop", false);
        }
        else
        {
            PlayLoop = true;
            btnLoopAnimator.SetBool("Loop", true);
        }
    }

    public void btnSelectSong()
    {
        SelectList = musicList;
        SelectList = SelectList.OrderBy(x => x.name).ToList();
        SelectSongPanel.SetActive(true);
        OrderByDropDown.ClearOptions();
        OrderByDropDown.AddOptions(OrderByList);
        OrderByDropDown.onValueChanged.AddListener(SetOrderBy);
        GenerateSelectMusicBox();
    }

    private void SetOrderBy(int index)
    {
        if (OrderByDropDown.value == 0) //name 
        {
            SelectList = SelectList.OrderBy(x => x.name).ToList();
        }
        else if (OrderByDropDown.value == 1)
        {
            SelectList = SelectList.OrderByDescending(x => x.name).ToList();
        }
        else if (OrderByDropDown.value == 2)//length
        {
            SelectList = SelectList.OrderBy(x => x.length).ToList();
        }
        else if (OrderByDropDown.value == 3)
        {
            SelectList = SelectList.OrderByDescending(x => x.length).ToList();
        }
        else
        {
            SelectList = musicList;
        }
        GenerateSelectMusicBox();
        //delete all child, spawn button
    }

    private void GenerateSelectMusicBox()
    {
        foreach (Transform child in SelectContent.transform)//delete all child
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (AudioClip clip in SelectList)
        {
            GameObject SelectMusicBox = Instantiate(SelectMusicBoxPrefab);
            SelectMusicBox.transform.SetParent(SelectContent.transform);
            int length = (int)clip.length;
            SelectMusicBox.transform.Find("txtName").GetComponent<Text>().text = clip.name;
            SelectMusicBox.transform.Find("txtLength").GetComponent<Text>().text = ((length / 60) % 60) + ":" + (length % 60).ToString("D2");
            SelectMusicBox.GetComponent<Button>().onClick.AddListener(delegate () { SelectMusicBoxClicked(clip); });
        }
    }

    private void SelectMusicBoxClicked(AudioClip getClip)
    {
        audioSource.clip = getClip;
        audioSource.time = 0;
        //
        AudioClip[] clipArray = musicList.ToArray();
        for (int i = 0; i < clipArray.Length; i++)
        {
            if (clipArray[i] == getClip)
            {
                PlayedHistory.Add(i);
                CurrentSongIndex = i;
            }
        }
        //
        audioSource.Play();
        UpdateName();
    }

    public void btnQuitSelectPanel()
    {
        SelectSongPanel.SetActive(false);
    }

    public void btnHideOrShowController()
    {
        ControllerAnimator.ResetTrigger("Hide");
        ControllerAnimator.ResetTrigger("Show");
        if (HideController)
        {
            HideController = false;
            ControllerAnimator.SetTrigger("Show");
            txtShowOrHideButton.text = "↓";
        }
        else
        {
            HideController = true;
            ControllerAnimator.SetTrigger("Hide");
            txtShowOrHideButton.text = "↑";
        }
    }

    public void btnSearch()
    {
        List<AudioClip> SearchList = new List<AudioClip>();
        foreach (AudioClip clip in musicList)
        {
            string clipName = clip.name.ToUpper();
            if (clipName.Contains(inputFieldSearch.text.ToUpper()))
            {
                SearchList.Add(clip);
            }
        }
        SelectList = SearchList;
        GenerateSelectMusicBox();
    }

    public void btnReset()
    {
        SelectList = musicList;
        SelectList.OrderBy(x => x.name).ToList();
        GenerateSelectMusicBox();
    }

    public void btnHome()
    {
        StartCoroutine(GameObject.FindObjectOfType<LoadingSystem>().LoadScene(0));
    }

    public void btnSetting()
    {
        GameObject.FindObjectOfType<Setting>().OpenSetting();
    }
}
