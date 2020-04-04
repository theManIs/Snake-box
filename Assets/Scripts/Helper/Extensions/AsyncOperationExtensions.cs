using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;
    
public sealed class AsyncOperationBehaviour : MonoBehaviour
{
}


public static partial class AsyncOperationExtensions 
{
    #region Fields
    
    private static AsyncOperationBehaviour _asyncOperationBehaviour = null;
    private static readonly List<Coroutine> _allCoroutines = new List<Coroutine>();
        
    #endregion


    #region Methods

    public static Coroutine StartCoroutine(this IEnumerator iterator, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = _asyncOperationBehaviour.StartCoroutine(RunTaskInner(iterator, finishCallback));
        if (asyncCoroutine != null)
        {
            _allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static Coroutine StartCoroutine(this AsyncOperation task, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = _asyncOperationBehaviour.StartCoroutine(RunTaskAsyncInner(task, finishCallback));
        if (asyncCoroutine != null)
        {
            _allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static Coroutine StartCoroutine(this WWW task, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = _asyncOperationBehaviour.StartCoroutine(RunTaskWwwInner(task, finishCallback));
        if (asyncCoroutine != null)
        {
            _allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static Coroutine StartCoroutine(this UnityWebRequest task, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = _asyncOperationBehaviour.StartCoroutine(RunTaskWwwInner(task, finishCallback));
        if (asyncCoroutine != null)
        {
            _allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static void StopCoroutine(this Coroutine coroutine)
    {
        if ((coroutine != null) && (_asyncOperationBehaviour))
        {
            if (_allCoroutines.Contains(coroutine))
            {
                _allCoroutines.Remove(coroutine);
                _asyncOperationBehaviour.StopCoroutine(coroutine);
            }
        }
    }

    private static void Initialize()
	{
		if (_asyncOperationBehaviour == null)
		{
			GameObject g = new GameObject();
            Object.DontDestroyOnLoad(g);
			g.name = "AsyncOperationExtensionCoroutine";
            g.hideFlags = HideFlags.HideAndDontSave;

            _asyncOperationBehaviour = g.AddComponent<AsyncOperationBehaviour>();
		}
	}

    private static IEnumerator RunTaskInner(IEnumerator task, Action finishCallback = null)
    {     
        while (task.MoveNext())
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }

    private static IEnumerator RunTaskAsyncInner(AsyncOperation task, Action finishCallback = null)
    {
        while (!task.isDone)
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }
       
    private static IEnumerator RunTaskWwwInner(WWW task, Action finishCallback = null) 
    {
        while (!task.isDone)
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }
    
    private static IEnumerator RunTaskWwwInner(UnityWebRequest task, Action finishCallback = null) 
    {
        while (!task.isDone)
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }

    #endregion
}