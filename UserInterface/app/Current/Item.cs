using System;
using System.Collections.Generic;

using CAB201;
using CHECKUSER;

namespace ITEM
{
    public class ItemData
    {
        /// Store all items
        public static List<string> dataItemName { get; set; }
        public static List<string> dataItemDescription { get; set; }
        public static List<int> dataItemCost { get; set; }

        public ItemData() 
        {
            dataItemName = new List<string>();
            dataItemDescription = new List<string>();
            dataItemCost = new List<int>();
        }

        public static void AddItem() 
        {
            dataItemName.Add(Item.itemName);
            dataItemDescription.Add(Item.itemDescription);
            dataItemCost.Add(Item.itemCost);

            UserData.myItem.Add(Item.itemName);
            UserData.myItemDescription.Add(Item.itemDescription);
            UserData.myItemCost.Add(Item.itemCost);

        }
        /// <summary>
        /// Display items the user listed
        /// </summary>
        public static void listMyItem()
        {
            string items = "";

            for (int i = 0; i < dataItemName.Count; i++)
            {
                items += dataItemName[i] + ", " + dataItemDescription[i] + "\n";
            }

            if (items == "")
            {
                Console.WriteLine("\nNo item listed right now. Register an item to see it.\n");
            }
            else
            {
                Console.WriteLine($"\nItems listed:\n{items}");
            }
        }
    }

    public class Item
    {   
        public static string itemName { get; set; }
        public static string itemDescription { get; set; }
        public static int itemCost { get; set; }

        public Item(string itemname, string itemdescription, int itemcost)
        {
            itemName = itemname;
            itemDescription = itemdescription;
            itemCost = itemcost;
        }

        /// <summary>
        /// Add Item to the "database"
        /// </summary>
        public static void RegisterItem()
        {
            string _itemName = UserInterface.GetInput("Item Name");
            string _itemDescription = UserInterface.GetInput("Item Description");
            int _itemCost = UserInterface.GetInt("Initial Bid ($)");

            Item newItem = new Item(_itemName, _itemDescription, _itemCost);
            ItemData.AddItem();

            Console.WriteLine($"\nItem '{_itemName}' with description '{_itemDescription}' registered sucessfully!\n");
        }

        /// <summary>
        /// Get all listed items. User can then choose one of the item to place a bid.
        /// </summary>
        public static void PlaceBid()
        {
            UserData.SearchItem();

            int option = UserInterface.GetInt("Choose an option");
            int bidCost = UserInterface.GetInt("Place Bid ($)");
            bool deliveryOption = UserInterface.GetBool ("Home Delivery");

            /// Calcualte taxable amount based on delivery option
            double taxPay = bidCost * 0.15;
            double deliveryCost = 5.00;

            if (deliveryOption == true)
            {
                taxPay += deliveryCost;
            }

            taxPay = Math.Round(taxPay, 2);

            Console.WriteLine($"\nYour sale tax payable will be ${taxPay} upon successful transaction.\n");
   
        }
    }
}

    
 