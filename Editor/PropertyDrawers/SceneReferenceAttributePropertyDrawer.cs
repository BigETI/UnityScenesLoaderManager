using UnityEditor;
using UnityEngine;
using UnityScenesLoaderManager;

/// <summary>
/// Unity scenes loader manager editor property drawers namespace
/// </summary>
namespace UnityScenesLoaderManagerEditor.PropertyDrawers
{
    /// <summary>
    /// A class that describes a scene reference attribute property drawer
    /// </summary>
    [CustomPropertyDrawer(typeof(SceneReferenceAttribute))]
    public sealed class SceneReferenceAttributePropertyDrawer : PropertyDrawer, ISceneReferenceAttributePropertyDrawer
    {
        /// <summary>
        /// Loads scene asset
        /// </summary>
        /// <param name="sceneAssetPath">Scene asset path</param>
        /// <returns>Scene asset if successful, otherwise "null"</returns>
        private static SceneAsset LoadSceneAsset(string sceneAssetPath) => string.IsNullOrEmpty(sceneAssetPath) ? null : (AssetDatabase.LoadAssetAtPath(sceneAssetPath, typeof(SceneAsset)) as SceneAsset);

        /// <summary>
        /// Is the specified scene asset path in build settings
        /// </summary>
        /// <param name="sceneAssetPath">Scene asset path</param>
        /// <returns></returns>
        private static bool IsSceneAssetPathAssetInBuildSettings(string sceneAssetPath)
        {
            bool ret = false;
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.path == sceneAssetPath)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets invoked when GUI need to be drawn
        /// </summary>
        /// <param name="position">Property position</param>
        /// <param name="property">Property</param>
        /// <param name="label">Label</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SceneReferenceAttribute scene_reference_attribute = (SceneReferenceAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.String)
            {
                SceneAsset scene_asset = EditorGUI.ObjectField(position, label, LoadSceneAsset(property.stringValue), typeof(SceneAsset), true) as SceneAsset;
                string scene_asset_path = (scene_asset == null) ? string.Empty : AssetDatabase.GetAssetPath(scene_asset);
                if (property.stringValue != scene_asset_path)
                {
                    if ((scene_asset == null) || scene_reference_attribute.IsAllowedToReferenceSceneWithoutBuildIndex || IsSceneAssetPathAssetInBuildSettings(scene_asset_path))
                    {
                        property.stringValue = scene_asset_path;
                        property.serializedObject.ApplyModifiedProperties();
                    }
                    else
                    {
                        Debug.LogWarning($"Scene \"{ scene_asset.name }\" at \"{ scene_asset_path }\" can not be used. Add this scene to the \"Scenes In Build\" in build settings first to reference it in the inspector.");
                    }
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use \"SceneReference\" attribute only for serializable strings.");
            }
        }
    }
}
