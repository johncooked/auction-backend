using System;

using CAB201;
using CHECKUSER;
using ITEM;

namespace MAIN {

	public class Program {

		static void Main(string[] args ) {
			/// Initialise the user "database"
			UserData newInstUser = new UserData();
			ItemData newInstItem = new ItemData();

			/// Check whether logged in state of the user and display the corresponding menu
			if (User.loggedIn == true)
			{
				SubMenu();
			}
			else 
			{
				MainMenu(newInstUser);
			}
		
		}

		/// <summary>
		/// Displays a menu allowing user to register or login.
		/// When user selects 2, program terminates.
		/// </summary>
		public static void MainMenu(UserData newInst) {
			const int REGISTER = 0, LOGIN = 1, EXIT = 2;

			bool runningMain = true;

			while ( runningMain ) {
				int option = UserInterface.GetOption("Please select one of the following",
					"Register as new client", "Login as existing Client", "Exit\n"
				);

				switch ( option ) {
					case REGISTER: 
						newInst.RegisterUser(); 
						break;
					case LOGIN:
						User.LoginUser();
						break;
					case EXIT: 
						runningMain = false; 
						break;
					default: break;
				}
			}
		}

		/// <summary>
		/// Displays a menu allowing user to choose what they would like to do.
		/// This menu only displays when the user is logged in.
		/// When user selects 6, program logouts.
		/// </summary>
		public static void SubMenu()
		{
			const int REGISTER_ITEM = 0, LIST_ITEM = 1, SEARCH_ITEM = 2, BID = 3, LISTBID = 4, SELLITEM = 5, CHECKRULE = 6, LOGGOUT = 7;

			bool runningSub = true;

			while (runningSub)
			{
				int option = UserInterface.GetOption("Please select one of the following",
					"Register item for sale", "List my items", "Search for items", "Place a bid on an item", "List bids recieved for my items", "Sell one of my item to highest bidder", "Check auction rules", "Loggout\n"
				);

				switch (option)
				{
					case REGISTER_ITEM:
						Item.RegisterItem();
						break;
					case LIST_ITEM:
						ItemData.listMyItem();
						break;
					case SEARCH_ITEM:
						UserData.SearchItem();
						break;
					case BID:
						Item.PlaceBid();
						break;
					case LISTBID:
						/// Not implemented
						break;
					case SELLITEM:
						/// Not implemented
						break;
					case CHECKRULE:
						AuctionRule();
						break;
					case LOGGOUT:
						runningSub = false;
						User.LogoutUser();
						break;
					default: break;
				}
			}
		}

		/// <summary>
		/// Print out a message of auction rules.
		/// </summary>
		private static void AuctionRule() {
			Console.WriteLine("\nSeller:");
			Console.WriteLine("Upon successful transactions, the seller will be charged an additional fee of $10 for 'Click and Collect' or $20 for 'Home Delivery'.\n");

			Console.WriteLine("Buyer:");
			Console.WriteLine("Upon successful transactions, the tax payable amount will be 15% of the product plus an additonal $5.\n");
		}
	}
}
