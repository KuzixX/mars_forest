using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Firestore;

namespace Client.Scripts.ECS.Components
{
    internal struct FirebaseComponent
    {
        public FirebaseFirestore Firestore;
        public FirebaseAuth Auth;
        public Dictionary<string, object> CellObjectData;
        public Dictionary<string, object> ObjectToSendToDB;
    }
}