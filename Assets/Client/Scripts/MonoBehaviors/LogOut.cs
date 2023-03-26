using Firebase.Auth;
using UnityEngine;

namespace Client.Scripts.MonoBehaviors
{
   public class LogOut : MonoBehaviour
   {
      public void Out()
      {
         FirebaseAuth auth = FirebaseAuth.DefaultInstance;
         if (auth.CurrentUser != null)
         {
            auth.SignOut();  
         }
      }
   }
}
