

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief MonoBehaviour。
*/


/** BlueBack.VariableDigit
*/
namespace BlueBack.VariableDigit
{
	/** InspectorViewer_MonoBehaviour
	*/
	public class InspectorViewer_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** decvalue
		*/
		#if(UNITY_EDITOR)
		public System.Collections.Generic.List<BlueBack.VariableDigit.DecValue> decvalue;
		#endif
	}
}

