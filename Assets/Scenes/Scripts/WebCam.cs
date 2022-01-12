using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
//using LetterboxCamera;

public class WebCam : MonoBehaviour
{

    //public static WebCam instance;
    public string deviceName;
    //public string recentScene;
    WebCamTexture wct;
    [Range(30, 60)]
    public int FPS;
    public GameObject Background;
    public int _Width, _Height;

    // Use this for initialization
    void Awake()
    {
        /*
		//recentScene = SceneManager.GetActiveScene().name;
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad(transform.gameObject);
		*/
        /*
		if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
		{
			// 카메라 퍼미션 설정
			Permission.RequestUserPermission(Permission.Camera);
		}
		if (WebCamTexture.devices.Length == 0)
		{
			// 디바이스가 없는 경우에는 Return 해줍시다.
			Debug.Log("No devices cameras found");
			return;
		}
		*/
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[0].name;
        
    }
    private void Start()
    {
        WindowManager.instance.ScreenSizeChangeEvent += Instance_ScreenSizeChangeEvent;
        wct = new WebCamTexture(deviceName, _Width, _Height, FPS);
        Background.GetComponent<Image>().material.mainTexture = wct;
        wct.Play();
    }
    private void Instance_ScreenSizeChangeEvent(int Width, int Height)
    {
        Debug.Log("Screen Size Width = " + Width.ToString() + "  Height = " + Height.ToString());
        _Width = Width; _Height = Height;
        wct = new WebCamTexture(deviceName, Width, Height, FPS);
        Background.GetComponent<Image>().material.mainTexture = wct;
        wct.Play();
    }
    /*
	void OnEnable()
	{
		// 씬 매니저의 sceneLoaded에 체인을 건다.
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	*/
    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //print(recentScene+"/"+scene.name);
    /*
    if (recentScene != scene.name)
    {
        //print("re");
        GetComponent<ForceCameraRatio>().cameraAssign();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
    //recentScene = SceneManager.GetActiveScene().name;
    //wct.Play();
    //}

    //void OnDisable()
    //{
    //SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
}
