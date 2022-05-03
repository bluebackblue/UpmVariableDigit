

/** BlueBack.VariableDigit.Samples.BusyDivision
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.BusyDivision
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

				//0 + 0 = 0
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			100),

				//0 + 0 = 0
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("1"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("16"),		100),

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
				BlueBack.VariableDigit.BusyConvert.ToStringBuilderWithLimit(this.decvalue[ii],t_stringbuilder,1000);
				UnityEngine.Debug.Log(string.Format("{0}",t_stringbuilder));
			}

			yield break;
		}
	}
}
#endif

