using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;

using TMPro;
using PlayFab.ClientModels;

public class PlayfabController : MonoBehaviour {
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public SceneChanger sceneChanger;
    public TextMeshProUGUI goldValueText;
   
   
        

   public void RegisterButton()
    {
        if (passwordInput.text.Length <= 6)
        {
            messageText.text = "Password is to short";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
}
 
   public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
          
        };   
      
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
        
    }
    void OnLoginSuccess(LoginResult result)
    {
        
        GetVirtualCurrencies();
        messageText.text = "Successful Login";
        sceneChanger.Scene2();

    }                 
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and Logged IN";
        GetVirtualCurrencies();
    }
    //Successful Login Section with beginning Gold Balance and Leaderboards

    void OnError(PlayFabError error)
    {
        messageText.text = "error";
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    
    }
    void OnLoginError(PlayFabError error)
    {
        switch(error.Error) {
            case PlayFabErrorCode.EmailAddressNotAvailable:
        messageText.text = ("Email Already Registered");
        Debug.LogWarning("Register Fail Email Already Registered");
                break;

            case PlayFabErrorCode.InvalidEmailAddress:
        messageText.text = ("Invalid Email");
        Debug.LogWarning("Register Fail Invalid Email");
                break;
            case PlayFabErrorCode.InvalidPassword:
                messageText.text = ("Password not correct");
                Debug.LogWarning("wrong password");
                break;
    }   
    }
    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }
  void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
       int gold = result.VirtualCurrency["FR"];
        goldValueText.text = gold.ToString();
    }
     
 }
