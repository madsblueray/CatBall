using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IDataPersistence, IUnityAdsLoadListener, IUnityAdsShowListener, Bootstrapped
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    public int priority = 1;
    public int Priority {get;}
    public int secondsBetweenAds;

    public int gamesBetweenAds;

    bool readyForAd;
    public bool ReadyForAd{ //just playing around and learning c#
        get{return readyForAd;}
        set{
            Debug.Log("readyForAd set to" + value);
            readyForAd = value;
        }
        
    }

    public static int winCount;

    public static bool adsTurnedOff;

    public void Initialize()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
        //subscribe a function to rewarded ads button click event (int magnitude)
        //subscribe a function to interstitial ad event
    }

    public void Start()
    {
        if(!adsTurnedOff)
        {
            InvokeRepeating("ReadyAd", secondsBetweenAds, secondsBetweenAds);
            WinConditionManager.winEvent += IncrementWinCount;
            LevelLoader.OnLevelChange += LaunchAd;
        }
    }

    public void LoadData(GameData data) => adsTurnedOff = data.adsTurnedOff;
    public void SaveData(ref GameData data) => data.adsTurnedOff = adsTurnedOff;

    void IncrementWinCount()
    {
        winCount++;
    }

    void ReadyAd()
    {
        Debug.Log(secondsBetweenAds + " seconds has passed");
        ReadyForAd = true;
    }

    public bool ShouldPlayAnAd()
    {
        if (ReadyForAd & winCount >= gamesBetweenAds)
        {
            resetAdCounterState();
            LoadAd();
            return true;
            
        }
        return false;
    }

    void resetAdCounterState()
    {
        winCount = 0;
        ReadyForAd = false;
    } 

    public void LaunchAd(int doesntmatter) //just to use the event i need an int input
    {
        if (ShouldPlayAnAd())
        {
            ShowAd();
        }

        else{
            Debug.Log("Not ready for ad yet, winCount is :" + winCount);
        }
    }

    //the following functions are provided by unity
    //~~~
    //~~~
 
    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
 
    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }
 
    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }
 
    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }
 
    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }


}
