

/** BlueBack.VariableDigit.Samples.Simple
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Simple
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** decvalue
		*/
		public System.Collections.Generic.List<BlueBack.VariableDigit.DecValue> decvalue;

		/** Awake
		*/
		private void Awake()
		{
			this.decvalue = new System.Collections.Generic.List<BlueBack.VariableDigit.DecValue>(){

				BlueBack.VariableDigit.DecValue.value_0,
				BlueBack.VariableDigit.DecValue.value_1,
				BlueBack.VariableDigit.DecValue.value_2,
				BlueBack.VariableDigit.DecValue.value_2_inverse,
				BlueBack.VariableDigit.DecValue.value_16,
				BlueBack.VariableDigit.DecValue.value_16_inverse,
			};
		}

		/** Start
		*/
		private void Start()
		{
			#if(UNITY_EDITOR)
			this.gameObject.AddComponent<BlueBack.VariableDigit.InspectorViewer_MonoBehaviour>().decvalue = this.decvalue;
			#endif

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			for(int ii=0;ii<this.decvalue.Count;ii++){
				BlueBack.VariableDigit.BusyConvert.ToStringBuilder(this.decvalue[ii],t_stringbuilder);
				UnityEngine.Debug.Log(t_stringbuilder.ToString());
			}

			yield break;
		}
	}
}
#endif

