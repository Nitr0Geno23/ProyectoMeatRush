using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown qualityDropdown; 


    private void Start()
    {
 
        PopulateQualityDropdown();

        qualityDropdown.value = QualitySettings.GetQualityLevel();

        qualityDropdown.onValueChanged.AddListener(SetQuality);
    }

    private void PopulateQualityDropdown()
    {

        qualityDropdown.ClearOptions();

        var qualityNames = new System.Collections.Generic.List<string>(QualitySettings.names);

        qualityDropdown.AddOptions(qualityNames);
    }

 
    public void SetQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("QualityLevel", level);  
    }

}
