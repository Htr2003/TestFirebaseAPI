using FirebaseAdmin.Auth;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestFirebaseAPI.Models;
using Newtonsoft.Json;

public class FirestoreController : Controller
{
    private FirestoreDb firestoreDb;

    public FirestoreController()
    {
        firestoreDb = FirestoreDb.Create("web-mvc-with-android");
    }

    public async Task<ActionResult> KhachHangList()
    {
        
        CollectionReference collection = firestoreDb.Collection("KhachHang"); // Replace with your collection name

        QuerySnapshot querySnapshot = await collection.GetSnapshotAsync();

        List<KhachHang> khachHangList = new List<KhachHang>();

        foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
        {
            if (documentSnapshot.Exists)
            {
                Dictionary<string, object> firestoreData = documentSnapshot.ToDictionary();

                // Convert the dictionary to a JSON string
                string firestoreJson = JsonConvert.SerializeObject(firestoreData);

                // Deserialize the JSON string into your KhachHang object
                KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(firestoreJson);

                if (firestoreData.ContainsKey("dob"))
                {
                    Timestamp timestamp = (Timestamp)firestoreData["dob"];
                    khachHang.dob = timestamp;
            
                }

                khachHangList.Add(khachHang);
            }
        }

        return View(khachHangList);
    }

  
}