using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Uncomment below after FacebookSDK initialized.
 */

 using Facebook.Unity;

public class FacebookSDKInitializer : MonoBehaviour
{
   
     
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            UnityEngine.Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            UnityEngine.Time.timeScale = 1;
        }
    }

   
}


