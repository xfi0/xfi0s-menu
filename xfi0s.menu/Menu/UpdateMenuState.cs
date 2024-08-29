using System;
using GorillaLocomotion;
using Il2CppSystem;
using Photon.Pun;
using Photon.Realtime;
using UnhollowerBaseLib;
using UnityEngine;

private static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType)
{
	try
	{
		if (!(OperationType == "optionhit"))
		{
			return;
		}
		if (option._type == "submenu")
		{
			if (option.AssociatedString == "Movement")
			{
				CurrentViewingMenu = Movement;
			}
			if (option.AssociatedString == "GhostMods")
			{
				CurrentViewingMenu = GhostMods;
			}
			if (option.AssociatedString == "MainStuff")
			{
				CurrentViewingMenu = MainStuff;
			}
			if (option.AssociatedString == "basicColors")
			{
				CurrentViewingMenu = BasicColors;
			}
			if (option.AssociatedString == "Settings")
			{
				CurrentViewingMenu = Settings;
			}
			if (option.AssociatedString == "Visual")
			{
				CurrentViewingMenu = Visual;
			}
			if (option.AssociatedString == "Back")
			{
				CurrentViewingMenu = MainMenu;
			}
			if (option.AssociatedString == "Projectiles")
			{
				CurrentViewingMenu = Projectiles
			}
			MenuState = option.AssociatedString;
			SelectedOptionIndex = 0;
		}
		if (option._type == "toggle")
		{
			if (!option.AssociatedBool)
			{
				option.AssociatedBool = true;
				Debug.Log(Object.op_Implicit($"<color=black>Toggled {option.DisplayName} : {option.AssociatedBool}</color>"));
			}
			else
			{
				option.AssociatedBool = false;
			}
		}
		if (option._type == "button")
		{
			if (option.AssociatedString == "Disconnect")
			{
				PhotonNetwork.LeaveRoom(true);
			}
			if (option.AssociatedString == "joinRandom")
			{
				PhotonNetwork.JoinRandomRoom();
			}
		}
		if (!(option._type == "button"))
		{
			return;
		}
		if (option.AssociatedString == "destroyAll")
		{
			PhotonNetwork.SetMasterClient(PhotonNetwork.get_LocalPlayer());
			foreach (Player item in (Il2CppArrayBase<Player>)(object)PhotonNetwork.get_PlayerListOthers())
			{
				PhotonNetwork.DestroyPlayerObjects(item);
			}
		}
		if (option.AssociatedString == "teleportToRandom")
		{
			Player[] array = Il2CppArrayBase<Player>.op_Implicit((Il2CppArrayBase<Player>)(object)PhotonNetwork.get_PlayerList());
			Random random = new Random();
			int num = random.Next(array.Length);
			PhotonView val = GorillaGameManager.get_instance().FindVRRigForPlayer(array[num]);
			if ((Object)(object)val != (Object)null)
			{
				((Component)Player.get_Instance()).get_transform().set_position(((Component)val).get_transform().get_position());
				((Component)Player.get_Instance()).GetComponent<Rigidbody>().set_velocity(new Vector3(0f, 0f, 0f));
			}
			foreach (MeshCollider item2 in Object.FindObjectsOfType<MeshCollider>())
			{
				((Collider)item2).set_enabled(false);
			}
		}
		if (option.AssociatedString == "Disconnect")
		{
			PhotonNetwork.LeaveRoom(true);
		}
	}
	catch
	{
	}
}
