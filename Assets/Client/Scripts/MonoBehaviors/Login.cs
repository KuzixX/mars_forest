using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;

namespace Client.Scripts.MonoBehaviors
{
    public class Login : MonoBehaviour
    {
        public UnityEvent onLogIn;

        public async void TriggerLogin()
        {
            FirebaseAuth auth = FirebaseAuth.DefaultInstance;

            if (auth.CurrentUser == null)
            {
                await auth.SignInAnonymouslyAsync().ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("SignInAnonymouslyAsync was canceled.");
                        return;
                    }

                    if (task.IsFaulted)
                    {
                        Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                        return;
                    }

                    FirebaseUser newUser = task.Result;
                    Debug.LogFormat("User signed in successfully: {0} ({1})",
                        newUser.DisplayName, newUser.UserId);

                });
            }

            var userName = auth.CurrentUser.UserId;
            onLogIn.Invoke();
            Debug.Log($"Logged in as {userName}");
        }
    }
}