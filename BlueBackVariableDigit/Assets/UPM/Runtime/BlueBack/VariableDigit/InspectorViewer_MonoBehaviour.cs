

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief MonoBehavioură€‚
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** InspectorViewer_MonoBehaviour
	*/
	public class InspectorViewer_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** editor_view_list
		*/
		#if(UNITY_EDITOR)
		public System.Collections.Generic.List<BlueBack.VariableDigit.DecValue> editor_view_list;
		#endif
	}
}

