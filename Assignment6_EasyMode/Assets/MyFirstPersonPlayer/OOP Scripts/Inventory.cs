/*
 * (no longer in use, for demo only)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Inventory : MonoBehaviour
    {
        [SerializeField]private InventoryItem item;
        public List<InventoryItem> inventory;

        void Start()
        {
            item = new InventoryItem();
            inventory = new List<InventoryItem>();
        }

    }

