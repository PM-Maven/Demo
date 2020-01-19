/****************************************************
    文件：ClientSession.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/15 12:5:56
	功能：客户端网络会话
*****************************************************/

using PENet;
using PEProtocol;
using UnityEngine;

public class ClientSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        GameRoot.AddTips("连接服务器成功");
        PECommon.Log("Connect To Server Succ");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("RcvPack CMD : " + ((CMD)msg.cmd).ToString());
        NetSvc.Instance.AddNetPkg(msg);
    }

    protected override void OnDisConnected()
    {
        GameRoot.AddTips("服务器断开连接");
        PECommon.Log("DisConnect To Server");
    }
}