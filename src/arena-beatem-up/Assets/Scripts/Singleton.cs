using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton abstract class used for singletons. 
/// Any singleton should inherit from this class.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour  
    where T : Singleton<T>
{

    #region Fields
    /// <summary>
    /// Singleton's static instance.
    /// </summary>
    private static T _instance;
    
    /// <summary>
    /// The suffix for the singleton GameObject.
    /// </summary>
    private const string _singletonSuffix = " (singleton)";

    /// <summary>
    /// Whether the singleton has been initialized.
    /// </summary>
    private bool mIsInitialized = false;
    #endregion
    
    #region Properties
    
    /// <summary>
    /// The singleton instance reference.
    /// </summary>
    public static T Instance {
        get
        {
            if (_instance == null)
                _instance = CreateInstance();
            return _instance; 
        }
    }
    #endregion
    
    public void Awake()
    {
        Instance.Initialize();
    }
    /// <summary>
    /// Creates a new instance of the singleton. 
    /// If no GameObject with this script is present in the scene, 
    /// it will create a singleton object with a T script attached.
    /// </summary>
    /// <returns>A singleton instance of type T.</returns>
    private static T CreateInstance()
    {
        //Check if there's an instance already created
        T script =  GameObject.FindObjectOfType<T>();
        
        if (script == null)
        {
            GameObject singleton = new GameObject();
            script = singleton.AddComponent<T>();
        }

        //Set the object's name to a singleton
        script.gameObject.name = typeof(T).Name + _singletonSuffix;

        script.Initialize();

        return script;
    }

    /// <summary>
    /// Initialization function called by the Singleton child classes.
    /// </summary>
    protected abstract void OnInitialize();

    /// <summary>
    /// Called either on Start() or when the isntance is first created.
    /// </summary>
    private void Initialize()
    {
        if (mIsInitialized)
            return;
        mIsInitialized = true;
        OnInitialize();
    }

    /// <summary>
    /// Called when this script is destroyed.
    /// </summary>
    public virtual void OnDestroy()
    {
        _instance = null;
    }
}
