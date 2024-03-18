using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] AudioSource bgSound;
    float offset;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        bgSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
       
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    // Method to control the mute state of bgSound
    public void SetBgSoundMute(bool mute)
    {
        bgSound.mute = mute;
    }
}
