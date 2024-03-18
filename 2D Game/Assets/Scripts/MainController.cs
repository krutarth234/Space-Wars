using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance;

    // Reference to sound manager
    public SoundManager SoundManager {  get; private set; }

    // Reference to UI manager
    public UIManager UIManager { get; private set; }
    void Awake()
    {
        //Instance creation.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Debug.Log("Leave me aloneeee.....");
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        // Initializing sound manager
        SoundManager = GetComponentInChildren<SoundManager>();

        // Initializing UI Manager
        UIManager = GetComponentInChildren<UIManager>();
    }
}
