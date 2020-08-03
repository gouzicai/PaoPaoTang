using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler
    {
    
    public static void Init()
    {
        NetManager.AddMsgListener("Register", OnRegister);
        NetManager.AddMsgListener("Login", OnLogin);
        NetManager.AddMsgListener("EnterGame", OnEnterGame);

    }

    public static void OnRegister(BaseInfo baseInfo)
    {
        RegisterInfo info = (RegisterInfo)baseInfo;
        if (info.isSuccess) Debug.Log("register success");
    }

    public static void OnLogin(BaseInfo baseInfo)
    {
        LoginInfo info = (LoginInfo)baseInfo;
        if (info.isSuccess) {
            SceneManager.LoadScene(1);
        }
    }

    public static void OnEnterGame(BaseInfo baseInfo)
    {
        EnterGameInfo info = (EnterGameInfo)baseInfo;
        if (info.isSuccess)
        {   
            SceneManager.LoadScene(1);
        }
    }
}

