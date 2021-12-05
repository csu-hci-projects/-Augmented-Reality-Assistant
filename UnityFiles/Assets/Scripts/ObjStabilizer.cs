using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjStabilizer : MonoBehaviour
{
    [SerializeField] private Transform[] transforms; //Holds a record of transforms in world space 128 is recommended size for stable tracking

    public void UpdateTransfrom() 
    {
        AddTransfrom(gameObject.transform);
        AverageTransfrom();
    }

    private void AddTransfrom(Transform toAdd) //Adds the current position to the array and shifts all previous values
    {
        for (int i = 0; i < transforms.Length - 1; i++)
        {
            var tempTrans = transforms[i + 1];
            transforms[i + 1] = transforms[i];
            transforms[i] = toAdd;

            toAdd = transforms[i + 1];
        }
    }

    private void AverageTransfrom() //Adds all transforms in the array together and averages their location
    {
        int count = 0;
        float posX = 0, posY = 0, posZ = 0, rotX = 0, rotY = 0, rotZ = 0;

        foreach (var t in transforms)
        {
            posX += t.position.x;
            posY += t.position.y;
            posZ += t.position.z;

            rotX += t.rotation.eulerAngles.x;
            rotY += t.rotation.eulerAngles.z;
            rotZ += t.rotation.eulerAngles.x;

            count++;
        }

        Vector3 averagePos = new Vector3((posX / count), (posY / count), (posZ / count));
        Vector3 averageRot = new Vector3((rotX / count), (rotY / count), (rotZ / count));

        transform.position = averagePos;
        transform.rotation.eulerAngles.Set(averageRot.x, averageRot.y, averageRot.z);
    }
}
