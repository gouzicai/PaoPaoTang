using ProtoBuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class NetManager
    {
        public static Socket socket;
	static List<BaseInfo> msgList = new List<BaseInfo>();
	//每一次Update处理的消息量
	readonly static int MAX_MESSAGE_FIRE = 10;
	static byte[] buff = new byte[1024];

	public static void Connect(string ip, int port)
	{
		socket = new Socket(AddressFamily.InterNetwork,
		SocketType.Stream, ProtocolType.Tcp);
		//状态判断
		if (socket != null && socket.Connected)
		{
			Debug.Log("Connect fail, already connected!");
			return;
		}
		socket.NoDelay = true;
		//Connect
		socket.BeginConnect(ip, port, ConnectCallback, socket);
		
	}

	//Connect回调
	private static void ConnectCallback(IAsyncResult ar)
	{
		try
		{
			Socket socket = (Socket)ar.AsyncState;
			socket.EndConnect(ar);
			Debug.Log("Socket Connect Succ ");
			Handler.Init();
			//开始接收
			socket.BeginReceive(buff, 0,buff.Length, 0, ReceiveCallback, socket);

		}
		catch (SocketException ex)
		{
		}
	}

	//Receive回调
	public static void ReceiveCallback(IAsyncResult ar)
	{
		try
		{
			//获取接收数据长度
			int count = socket.EndReceive(ar);
			byte[] data = buff.Take(count).ToArray();
			foreach (var d in data)
			{
				Debug.Log(d);
			}
			BaseInfo baseInfo = ProtoHelper.Deserialize<BaseInfo>(data);
			//添加到消息队列
			lock (msgList)
			{
				msgList.Add(baseInfo);
			}
			buff = Array.Empty<byte>();
			foreach (var d in buff)
			{
				Debug.Log(d);
			}
			socket.BeginReceive(buff,0,buff.Length, 0, ReceiveCallback, buff);
		}
		catch (SocketException ex)
		{
			Debug.Log("Socket Receive fail" + ex.ToString());
		}
	}

	public static void Update()
    {
		MsgUpdate();
    }
	public static void MsgUpdate()
    {
		//初步判断，提升效率
		if (msgList.Count == 0)
		{
			return;
		}
		//重复处理消息
		for (int i = 0; i < MAX_MESSAGE_FIRE; i++)
		{
			//获取第一条消息
			BaseInfo baseInfo = null;
			lock (msgList)
			{
				if (msgList.Count > 0)
				{
					baseInfo = msgList[0];
					msgList.RemoveAt(0);
				}
			}
			Debug.Log(baseInfo);
			//分发消息
			if (baseInfo != null)
			{
				FireMsg(baseInfo.protoName, baseInfo);
			}
			//没有消息了
			else
			{
				break;
			}
		}
	}



















	//消息委托类型
	public delegate void MsgListener(BaseInfo baseInfo);
	//消息监听列表
	private static Dictionary<string, MsgListener> msgListeners = new Dictionary<string, MsgListener>();
	//添加消息监听
	public static void AddMsgListener(string msgName, MsgListener listener)
	{
		//添加
		if (msgListeners.ContainsKey(msgName))
		{
			msgListeners[msgName] += listener;
		}
		//新增
		else
		{
			msgListeners[msgName] = listener;
		}
	}
	//删除消息监听
	public static void RemoveMsgListener(string msgName, MsgListener listener)
	{
		if (msgListeners.ContainsKey(msgName))
		{
			msgListeners[msgName] -= listener;
		}
	}
	//分发消息
	private static void FireMsg(string msgName, BaseInfo baseInfo)
	{
		if (msgListeners.ContainsKey(msgName))
		{
			msgListeners[msgName](baseInfo);
		}
	}


	public static void Send(BaseInfo info)
	{
		byte[] data = ProtoHelper.Serialize(info);
	 	BaseInfo a = ProtoHelper.Deserialize<BaseInfo>(data);
		socket.BeginSend(data, 0, data.Length, 0,SendCallback, null);
	}

	//Send回调
	public static void SendCallback(IAsyncResult ar)
	{
	}

}

