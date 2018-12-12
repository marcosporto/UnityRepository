using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NameSpace
using UnityEngine.UI; // Trabalhar com objetos de interface de usuário

public class Configuracoes : MonoBehaviour {

    // Declaração das variáveis
    public bool     isFullScreen;
    public int      resolutionIndex;
    public int      qualityTexture;
    public float    musicVolume;

    // Declaração dos objetos
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropDown;
    public Dropdown qualityTextureDropDown;
    public Slider musicVolumeSlider;

    // Resoluções do monitor passadas à matriz
    public Resolution[] resolutions;

    // Função chamada quando os objetos estiverem ativos na cena (quando à cena for executada)
    private void OnEnable() {
        // Recebe todas às resoluções suportadas pelo monitor, no Android há matriz vem vazia
        resolutions = Screen.resolutions;

        // Loop caminha por todas resoluções armazenadas
        foreach (Resolution resolution in resolutions) {
            // Adiciona no DropDown resolução por resolução
            resolutionDropDown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        // Associando às funções aos objetos presentes na tela

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropDown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        qualityTextureDropDown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Se o minitor está em Full Screen
    public void OnFullScreenToggle() {

        Screen.fullScreen = fullScreenToggle.isOn;
        OnResolutionChange();
        //Debug.Log("Toggle da Tela Cheia ativado" + fullScreenToggle.isOn);
    }

    // Se a resolução foi mudada
    public void OnResolutionChange() {
        Screen.SetResolution(
            resolutions[resolutionDropDown.value].width,
            resolutions[resolutionDropDown.value].height,
            fullScreenToggle.isOn
       );
        Debug.Log("resolutions[resolutionDropDown.value].width" + resolutions[resolutionDropDown.value].width);
        Debug.Log("resolutions[resolutionDropDown.value].height" + resolutions[resolutionDropDown.value].height);
        Debug.Log("fullScreenToggle.isOn" + fullScreenToggle.isOn);
    }

    // Se a qualidade da textura foi mudada
    public void OnTextureQualityChange() {

        QualitySettings.SetQualityLevel(qualityTextureDropDown.value);
        
    }

    public void OnMusicVolumeChange() {

    }
}
