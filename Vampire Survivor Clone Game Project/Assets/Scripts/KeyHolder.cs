using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    private List<KeyScript.KeyType> keyList;
    public List<KeyScript.KeyType> GetKeyList()
    {
        return keyList;
    }
    private void Awake()
    {
        keyList = new List<KeyScript.KeyType>();
    }
    
    public void AddKey(KeyScript.KeyType keyType)
    {
        Debug.Log("Added Key :" + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveKey(KeyScript.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }
    public bool ContainsKey(KeyScript.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        KeyScript key = collider.GetComponent<KeyScript>();
        if(key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                // Currently holding Key to Open this door
                keyDoor.OpenDoor();
                RemoveKey(keyDoor.GetKeyType());
            }
        }
    }
}
