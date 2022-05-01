

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief CustomEditor。
*/


/** BlueBack.VariableDigit.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.VariableDigit.Editor
{
	/** DecValue_CustomEditor
	*/
	[UnityEditor.CustomEditor(typeof(InspectorViewer_MonoBehaviour),true)]
	public sealed class DecValue_CustomEditor : UnityEditor.Editor
	{
		/** expanded
		*/
		private System.Collections.Generic.Dictionary<string,bool> expanded;

		/** GetExpanded
		*/
		public bool GetExpanded(string a_address)
		{
			if(this.expanded == null){
				this.expanded = new System.Collections.Generic.Dictionary<string,bool>();
			}
		
			if(this.expanded.ContainsKey(a_address) == true){
				return this.expanded[a_address];
			}else{
				return false;
			}
		}

		/** SetExpanded
		*/
		public bool SetExpanded(string a_address,bool a_flag)
		{
			if(this.expanded == null){
				this.expanded = new System.Collections.Generic.Dictionary<string,bool>();
			}

			if((a_flag == true)||(this.expanded.ContainsKey(a_address) == true)){
				this.expanded[a_address] = a_flag;
			}

			return a_flag;
		}

		/**OnInspectorGUI
		*/
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			InspectorViewer_MonoBehaviour t_this = this.target as InspectorViewer_MonoBehaviour;

			UnityEditor.EditorGUILayout.Space(18);

			//シングル。
			{
				BlueBack.VariableDigit.DecValue t_jsonitem = t_this.GetDecValue();
				if(t_jsonitem != null){
					this.Draw("s",t_jsonitem);
					UnityEditor.EditorGUILayout.Space(18);
				}
			}

			//マルチ。
			{
				BlueBack.VariableDigit.DecValue[] t_jsonitem_list = t_this.GetMultiDecValue();
				if(t_jsonitem_list != null){
					for(int ii=0;ii<t_jsonitem_list.Length;ii++){
						this.Draw(ii.ToString(),t_jsonitem_list[ii]);
						UnityEditor.EditorGUILayout.Space(18);
					}
				}
			}
		}

		/** Separator
		*/
		public static void Separator()
		{
			UnityEngine.Color t_backup = UnityEngine.GUI.color;
			UnityEngine.GUI.color = UnityEngine.Color.red;

			UnityEditor.EditorGUILayout.BeginHorizontal();
			UnityEngine.GUILayout.Space(UnityEditor.EditorGUI.indentLevel * 15);
			UnityEngine.GUILayout.Box("",UnityEngine.GUILayout.ExpandWidth(true),UnityEngine.GUILayout.Height(5));
			UnityEditor.EditorGUILayout.EndHorizontal();

			UnityEngine.GUI.color = t_backup;
		}

		/** Draw
		*/
		public void Draw(string a_address,BlueBack.VariableDigit.DecValue a_decvalue)
		{
			if(a_decvalue == null){
				 UnityEditor.EditorGUILayout.LabelField("null");
			}else{
				string t_name = string.Format("{0} : exponent = {1} : count = {2}",(a_decvalue.sign > 0) ? ('+') : ('-'),a_decvalue.exponent,a_decvalue.list.Count);

				System.Collections.Generic.LinkedListNode<int> t_node = a_decvalue.list.First;
				if(this.SetExpanded(a_address,UnityEditor.EditorGUILayout.Foldout(this.GetExpanded(a_address),t_name)) == true){
					UnityEditor.EditorGUI.indentLevel++;

					long t_index = - a_decvalue.exponent - 1;
					while(t_node != null){
						UnityEditor.EditorGUILayout.LabelField(string.Format("{0:d2}",t_node.Value));
						t_node = t_node.Next;
						t_index = (t_index + 1) % 10;

						if(t_index == 0){
							Separator();
						}
					}

					UnityEditor.EditorGUI.indentLevel--;
				}
			}
		}
	}
}
#endif

