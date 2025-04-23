using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject playButton;
    public GameObject optionButton;
    public GameObject creditsButton;
    public GameObject titleCard;

    public GameObject optionMenu;
    public TextMeshProUGUI volumeAmnt;
    public TextMeshProUGUI freakAmnt;

    public GameObject quitText;
    public GameObject optionText;
    public GameObject playText;
    public GameObject creditsText;

    public AudioClip hover;
    public AudioClip exitOptions;
    public AudioClip volUp;
    public AudioClip volDown;
    public AudioClip error;
    public AudioSource AudioSource;
    public AudioSource AudioSource2;
   

    public AudioMixer myMixer;



    public float freak = 50f;
    public float volume = 50f;
    public bool canPlay = true;
        

    public void Start()
    {
        Cursor.visible = true;

        AudioSource = GetComponent<AudioSource>();
        AudioSource2 = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            loadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", volume - 80);
            myMixer.SetFloat("music", volume - 80);
        

        }
    }

    public void Update()
    {
        freakAmnt.text = freak.ToString();
        volumeAmnt.text = volume.ToString();
    }


    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        Cursor.visible = false;
    }   
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        canPlay = false;
        quitButton.SetActive(false);
        playButton.SetActive(false);
        optionButton.SetActive(false);
        creditsButton.SetActive(false);
        titleCard.SetActive(false);
        optionMenu.SetActive(true);
        optionText.SetActive(false);
    }

    public void CloseOptions()
    {
        
        AudioSource2.clip = exitOptions;
        AudioSource2.Play();

        quitButton.SetActive(true);
        playButton.SetActive(true);
        optionButton.SetActive(true);
        titleCard.SetActive(true);
        optionMenu.SetActive(false);
        optionText.SetActive(true);
        creditsButton.SetActive(true);

    }


    public void bigVolDecrease()
    {
        if (volume > 0) {
            AudioSource.clip = volDown;
            AudioSource.Play();
            volume -= 10;
            PlayerPrefs.SetFloat("musicVolume", volume);
            myMixer.SetFloat("music", volume - 80);
            
        } else 
        {
            AudioSource.clip = error;
            AudioSource.Play();
        }
    }

    public void bigVolIncrease()
    {
        if (volume < 100)
        {
            AudioSource.clip = volUp;
            AudioSource.Play();
            volume += 10;
            PlayerPrefs.SetFloat("musicVolume", volume - 80);
            myMixer.SetFloat("music", volume - 80);
            
        }
        else
        {
            AudioSource.clip = error;
            AudioSource.Play();
        }
    }

    public void loadVolume()
    {
        volume = PlayerPrefs.GetFloat("musicVolume", volume - 80) + 80;


    }



    public void bigFreakDecrease()
    {
        if (freak > 0)
        {
            AudioSource.clip = volDown;
        AudioSource.Play();
        freak -= 10;
        } else
            {
            AudioSource.clip = error;
            AudioSource.Play();
            }
    }

    public void bigFreakIncrease()
    {
        if (freak < 100)
        {
            AudioSource.clip = volUp;
            AudioSource.Play();
            freak += 10;
        }
        else
        {
            AudioSource.clip = error;
            AudioSource.Play();
        }
    }



    public void Credits()
    { 
        SceneManager.LoadSceneAsync(2);
    }


    public void showQuit()
    {
        quitText.SetActive(true);
        AudioSource.clip = hover;
        AudioSource.Play();
        canPlay = true;
    }

    public void hideQuit()
    {
        quitText.SetActive(false);
    }

    public void showOption()
    {
        optionText.SetActive(true);
        AudioSource.clip = hover;
        AudioSource.Play();
        canPlay = true;
    }

    public void hideOption()
    {
        optionText.SetActive(false);

    }

    public void showPlay()
    {
        playText.SetActive(true);
        AudioSource.clip = hover;
        AudioSource.Play();
        canPlay = true;
    }

    public void hidePlay()
    {
        playText.SetActive(false);
    }

    public void showCredits()
    {
        if (canPlay == true)
        {
            creditsText.SetActive(true);
            AudioSource.clip = hover;
            AudioSource.Play();
        }
    }
    public void hideCredits()
    {
        creditsText.SetActive(false);

    }

}
