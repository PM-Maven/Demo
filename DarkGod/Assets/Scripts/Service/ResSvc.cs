/****************************************************
    文件：ResSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:36:14
	功能：资源加载服务
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{
    public static ResSvc Instance = null;

    public void InitSvc() 
    {
        Instance = this;
        Debug.Log("Init ResSvc...");
    }

    /// <summary>
    /// 更新回调
    /// </summary>
    private Action prgCB = null;

    public void AsyncLoadScene(string sceneName) 
    {
        AsyncOperation sceneAsync =  SceneManager.LoadSceneAsync(sceneName);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWind.SetProgress(val);
            if (val == 1)
            {
                prgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWind.gameObject.SetActive(false);
            }
        };
    }    

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }
}