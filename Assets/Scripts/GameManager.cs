using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public  class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  GameObject[] playerGOArr;
    [Header("Player Prefab")]
    private Player[] players = new Player[4];
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        NetManager.Connect("127.0.0.1",8888);
        var myLoadedAssetBundle
            = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "props"));

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        PropMgr.PropList.Add(myLoadedAssetBundle.LoadAsset<GameObject>("sodaCan"));
        PropMgr.PropList.Add(myLoadedAssetBundle.LoadAsset<GameObject>("turkey"));
        PropMgr.PropList.Add(myLoadedAssetBundle.LoadAsset<GameObject>("watermelon"));
    }

    private void Update()
    {
        NetManager.Update();
    }

    public void CreatePlayer(int playerId)
    {
        Debug.Log("success init");
    }
    [Header("Login & Register")]
    public InputField username;
    public InputField password;
    public void Register()
    {
        RegisterInfo info = new RegisterInfo(username.text,password.text);
        NetManager.Send(info);
    }    
    public void Login()
    {
        LoginInfo info = new LoginInfo(username.text,password.text);
        NetManager.Send(info);
    }
}
