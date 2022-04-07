using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace BrokenVector.FavoritesList
{
    [System.Serializable]
    public class ListData : ScriptableObject
    {

        public List<ObjectReference> References = new List<ObjectReference>();

        public void AddReference(ObjectReference obj)
        {
            References.Add(obj);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        public void RemoveReference(ObjectReference obj)
        {
            References.Remove(obj);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        public void MoveReferenceDown(ObjectReference obj)
        {
            int objIndex = References.IndexOf(obj);
            if (objIndex - 1 >= 0)
            {
                ObjectReference refUp = References[objIndex - 1];
                References[objIndex - 1] = obj;
                References[objIndex] = refUp;
            }
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        public void MoveReferenceUp(ObjectReference obj)
        {
            int objIndex = References.IndexOf(obj);
            if (objIndex + 1 < References.Count)
            {
                ObjectReference refDown = References[objIndex + 1];
                References[objIndex + 1] = obj;
                References[objIndex] = refDown;
            }
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        public void Clear()
        {
            References.Clear();
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        public static ListData LoadList()
        {
            ListData list = AssetDatabase.LoadAssetAtPath(GetAssetLocation(), typeof(ListData)) as ListData;
            if (list != null)
                return list;

            list = CreateInstance<ListData>();
            AssetDatabase.CreateAsset(list, GetAssetLocation());
            AssetDatabase.SaveAssets();

            return list;
        }

        private static string GetAssetLocation()
        {
            var guid = AssetDatabase.FindAssets("ListData")[0];
            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (path.EndsWith(".cs"))
                return path.Remove(path.Length - 2) + "asset"; // .cs to .asset
            else
                return path;
        }

    }
}
