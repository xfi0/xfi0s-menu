using UnityEngine;
using UnityEngine.UI;

public static bool GUIToggled = true;
private static TextAnchor textAnchor = (TextAnchor)2;
private static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
public static string MenuState = "Main";
public static string MenuColour = "blue";
public static bool MenuRGB = false;
public static float menurgb = 1f;
public static int SelectedOptionIndex = 0;
public static MenuOption[] CurrentViewingMenu = null;
public static bool inputcooldown = false;
public static bool menutogglecooldown = false;
public static bool driftmode = false;
