using UnityEngine;
using TMPro;

public class Color_game_script
{
    public class PlayerInput : MonoBehaviour
{
    public TMP_InputField inputField;

    public void ReadInput()
    {
        string playerText = inputField.text;
        Debug.Log(playerText);
    }
}
}
