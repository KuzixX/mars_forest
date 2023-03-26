using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.Events;

namespace Client.Scripts.MonoBehaviors
{
    public class FirestoreController : MonoBehaviour
    {
        public UnityEvent onAddedUserToFirestore;
        public void AddDoc()
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                FirebaseAuth auth = FirebaseAuth.DefaultInstance;
                FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    {
                        "UID", auth.CurrentUser.UserId
                    },
                    {
                        "SignIn Date Time" , System.DateTime.Now
                    }
                };

                firestore.Collection("Users").Document(auth.CurrentUser.UserId).SetAsync(data).ContinueWith(
                    task =>
                    {
                        if (task.IsCompleted)
                        {
                            Debug.Log("User was added");
                        }

                        if (task.IsFaulted)
                        {
                            Debug.Log("Something went wrong");
                        }
                    });
            });

        }
    }
}