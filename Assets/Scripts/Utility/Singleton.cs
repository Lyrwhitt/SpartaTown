using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T sInstance;

    public static T Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = (T)FindObjectOfType(typeof(T));
            }

            if (sInstance == null)
            {
                Create();
            }

            return sInstance;
        }
    }

    private static void Create()
    {
        if (GameObject.Find("Singleton"))
        {
            GameObject goInst = GameObject.Find("Singleton");
            sInstance = goInst.AddComponent<T>();
        }
        else
        {
            GameObject goInst = new GameObject("Singleton");
            sInstance = goInst.AddComponent<T>();

            Debug.Log("Create Singleton " + goInst.name);
        }
    }
}

