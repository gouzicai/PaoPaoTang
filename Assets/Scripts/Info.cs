using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


[ProtoContract]
[ProtoInclude(11, typeof(RegisterInfo))]
[ProtoInclude(12, typeof(LoginInfo))]
public class BaseInfo
{
    [ProtoMember(1)]
    public string protoName = "";

}
[ProtoContract]
public class RegisterInfo : BaseInfo
{
    public RegisterInfo() { protoName = "Register"; }
    public RegisterInfo(string username, string password) { protoName = "Register"; this.username = username; this.password = password; }
    [ProtoMember(1)]
    public string username;
    [ProtoMember(2)]
    public string password;
    //服务端
    [ProtoMember(3)]
    public bool isSuccess;
}
[ProtoContract]
public class LoginInfo : BaseInfo
{
    public LoginInfo() { protoName = "Login"; }
    public LoginInfo(string username, string password) { protoName = "Login"; this.username = username; this.password = password; }
    [ProtoMember(1)]
    public string username;
    [ProtoMember(2)]
    public string password;
    //服务端
    [ProtoMember(3)]
    public bool isSuccess;
    [ProtoMember(4)]
    public int playerId;
}
[ProtoContract]
public class EnterGameInfo : BaseInfo
{
    public EnterGameInfo() { protoName = "EnterGame"; }
    public EnterGameInfo(int playerId) { protoName = "EnterGame"; this.playerId = playerId; }
    //服务端
    [ProtoMember(1)]
    public int playerId;
    [ProtoMember(2)]
    public bool isSuccess;
    public List<PlayerInfo> players;
}

public class PlayerInfo
{
    public int playerId;
    public float x;
    public float y;
    public float z;
    public float rx;
    public float ry;
    public float rz;
}




