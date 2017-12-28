using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class FormManager : MonoBehaviour {

    public InputField emailInput;
    public InputField passwordInput;

    public Button signUpButton;
    public Button loginButton;

    public Text statusText;

    public AuthManager authManager;

	void Awake () {
        ToggleButtonStates(false);

        // Auth Delegate subscriptions
        authManager.authCallback += HandleAuthCallback;
	}

    public void ValidateEmail()
    {
        string email = emailInput.text;
        Debug.Log("Validating email address... " + email);
        ToggleButtonStates(true);
    }

    public void OnSignUp()
    {
        authManager.SignUpNewUser(emailInput.text, passwordInput.text);
        Debug.Log("Sign Up");
    }

    public void OnLogin()
    {
        authManager.LoginExistingUser(emailInput.text, passwordInput.text);
        Debug.Log("Login");
    }

    IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation)
    {
        if (task.IsFaulted || task.IsCanceled)
        {
            UpdateStatus("Sorry, ERROR: " + task.Exception);
        }
        else if (task.IsCompleted)
        {
            Firebase.Auth.FirebaseUser newPlayer = task.Result;
            UpdateStatus("Loading the game scene...Welcome to Hell! " + newPlayer.Email);

            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("JSON Comm Demo");
        }
    }

    void onDestroy()
    {
        authManager.authCallback -= HandleAuthCallback;
    }

    private void ToggleButtonStates(bool toState)
    {
        signUpButton.interactable = toState;
        loginButton.interactable = toState;
    }

    private void UpdateStatus(string message)
    {
        statusText.text = message;
    }
}