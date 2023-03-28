//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEditor.IMGUI.Controls;

//public class LocalizationWindow : EditorWindow
//{
//    // SerializeField is used to ensure the view state is written to the window 
//    // layout file. This means that the state survives restarting Unity as long as the window
//    // is not closed. If the attribute is omitted then the state is still serialized/deserialized.
//    [SerializeField] TreeViewState m_TreeViewState;

//    //The TreeView is not serializable, so it should be reconstructed from the tree data.
//    SimpleTreeView m_SimpleTreeView;

//    [MenuItem("Window/LocalizationWindow")]
//    public static void ShowWindow()
//    {
//        EditorWindow.GetWindow(typeof(LocalizationWindow));
//    }

//    void OnEnable()
//    {
//        // Check whether there is already a serialized view state (state 
//        // that survived assembly reloading)
//        if (m_TreeViewState == null)
//            m_TreeViewState = new TreeViewState();

//        m_SimpleTreeView = new SimpleTreeView(m_TreeViewState);
//    }

//    void OnGUI()
//    {
//        EditorGUILayout.LabelField("Перевод полей");
//        m_SimpleTreeView.OnGUI(new Rect(0, 0, position.width, position.height));
//    }
//}

//class SimpleTreeView : TreeView
//{
//    public SimpleTreeView(TreeViewState treeViewState)
//        : base(treeViewState)
//    {
//        Reload();
//    }

 
//    protected override TreeViewItem BuildRoot()
//    {
//        var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
//        var animals = new TreeViewItem { id = 1, displayName = "Animals" };
//        var mammals = new TreeViewItem { id = 2, displayName = "Mammals" };
//        var tiger = new TreeViewItem { id = 3, displayName = "Tiger" };
//        var elephant = new TreeViewItem { id = 4, displayName = "Elephant" };
//        var okapi = new TreeViewItem { id = 5, displayName = "Okapi" };
//        var armadillo = new TreeViewItem { id = 6, displayName = "Armadillo" };
//        var reptiles = new TreeViewItem { id = 7, displayName = "Reptiles" };
//        var croco = new TreeViewItem { id = 8, displayName = "Crocodile" };
//        var lizard = new TreeViewItem { id = 9, displayName = "Lizard" };

//        root.AddChild(animals);
//        animals.AddChild(mammals);
//        animals.AddChild(reptiles);
//        mammals.AddChild(tiger);
//        mammals.AddChild(elephant);
//        mammals.AddChild(okapi);
//        mammals.AddChild(armadillo);
//        reptiles.AddChild(croco);
//        reptiles.AddChild(lizard);

//        SetupDepthsFromParentsAndChildren(root);

//        return root;
//    }
//}
