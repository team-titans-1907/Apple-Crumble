using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public GameObject emailValidator;
    public GameObject pwValidator;
    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
     

        var postRequest = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        Debug.Log("this is thes post request" + postRequest);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();
        if (!postRequest.isNetworkError || !postRequest.isHttpError)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            Debug.Log("this is name" + nameField.text + passwordField.text);
        }
        else
        {
            Debug.Log("this was not successful. Error" + www);
        }
    }
    public void VerifyInputs()
    {
        emailValidator.SetActive(false);
        pwValidator.SetActive(false);
        if(passwordField.text.Length < 4){
            pwValidator.SetActive(true);
        }
        if (Regex.IsMatch(nameField.text, MatchEmailPattern) == false)
        {
            emailValidator.SetActive(true);
        }
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);

    }

}
