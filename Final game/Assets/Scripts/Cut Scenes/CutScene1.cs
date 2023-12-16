using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

//Script repurposed for all cutscenes
public class VideoEndSceneChanger : MonoBehaviour
{
    //get videoplayer, next scenename
    public VideoPlayer videoPlayer;
    public string sceneName;

    public string videoName;

    void Start()
    {
        //get video , with abstracted path for webgl
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath, videoName); 
        //when video ends, go to endreached function to load next scene
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        //load next scene
        SceneManager.LoadScene(sceneName); 
    }
}