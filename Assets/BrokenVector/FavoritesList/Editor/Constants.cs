using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace BrokenVector.FavoritesList
{
	public static class Constants
	{

        // Plugin Info
        public const string ASSET_NAME = "Favorites List";

        // Editor Window
        public const string WINDOW_PATH = "Tools/" + ASSET_NAME;
        public const string WINDOW_PATH_ALT = "Window/" + ASSET_NAME;

        // Editor Pref Paths
        public const string DEBUG_PREF = "Debug";                               // has to match FavoritesListReference.DEBUG_PREF (with AssetPrefs)

    }
}
