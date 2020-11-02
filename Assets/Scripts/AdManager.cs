using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{

    //These are to set up real advertisements. I won't be using it but if implemented, it 100% works. 
    private string playStoreID = "7654321"; // fictional ID. Find your ID on Unity Dashboard.
    private string appStoreID = "1234567"; // fictional ID. Find your ID on Unity Dashboard.

    private string rewardedAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public GameObject AdObject;


    private void Start()
    {
        AdObject.SetActive(true);
        Advertisement.AddListener(this);
        InitializeAds();
    }


    private void InitializeAds()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;

        }
        Advertisement.Initialize(appStoreID, isTestAd);
    }


    public void playRewardAd()
    {
        AdObject.SetActive(false);
        if (!Advertisement.IsReady(rewardedAd))
        {
            return;
        }
        Advertisement.Show(rewardedAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedAd)
                {
                    UpdateHealth();
                    //update Canvas Health
                    Debug.Log("Reward Successful");
                }
                break;
        }
    }

    public void UpdateHealth()
    {
        PlayerStats.health = 5;
    }
}
