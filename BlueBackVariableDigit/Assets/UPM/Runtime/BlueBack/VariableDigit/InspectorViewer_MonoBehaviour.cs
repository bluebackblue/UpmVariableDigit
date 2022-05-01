

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
	public abstract class InspectorViewer_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** [BlueBack.VariableDigit.InspectorViewer_MonoBehaviour]表示物の取得。
		*/
		#if(UNITY_EDITOR)
		public virtual BlueBack.VariableDigit.DecValue GetDecValue()
		{
			return null;
		}
		#endif

		/** [BlueBack.VariableDigit.InspectorViewer_MonoBehaviour]表示物の取得。
		*/
		#if(UNITY_EDITOR)
		public virtual BlueBack.VariableDigit.DecValue[] GetMultiDecValue()
		{
			return null;
		}
		#endif
	}
}

