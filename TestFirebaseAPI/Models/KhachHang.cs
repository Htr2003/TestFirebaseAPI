using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFirebaseAPI.Models
{
    public class KhachHang
    {
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public Timestamp dob { get; set; }
    }
}