using UnityEngine;

public class SerializeManager : MonoBehaviour
{
    public static SerializeManager INSTANCE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INSTANCE = this;
    }

    public void LoadGame()
    {
        // Save current level
        string level = PlayerPrefs.GetString("level");

        LevelManager.INSTANCE.LoadLevel(level, true);
    }

    public void LoadGameData()
    {
        // Load all the serialized data into runtime memory
        float posx = PlayerPrefs.GetFloat("posx");
        float posy = PlayerPrefs.GetFloat("posy");
        float posz = PlayerPrefs.GetFloat("posz");

        int lives = PlayerPrefs.GetInt("health");


        Debug.Log("Loading scene data");
    }

    public void SaveGame()
    {
        // Save all the runtime data into serialized memory
        // Save position, save health, inventory, 

        //PlayerPrefs.SetFloat("posx", hCtr.transform.position.x);
        //PlayerPrefs.SetFloat("posy", hCtr.transform.position.y);
        //PlayerPrefs.SetFloat("posz", hCtr.transform.position.z);


        // Save current level
        PlayerPrefs.SetString("level", LevelManager.INSTANCE.activeLevel);

        // Save objects state

        // Save the data into file
        PlayerPrefs.Save();
    }
}
