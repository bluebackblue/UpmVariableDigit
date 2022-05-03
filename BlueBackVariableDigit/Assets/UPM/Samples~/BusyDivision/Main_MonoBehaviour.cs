

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

				//1 / 16 = 0.0625
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("1"),				BlueBack.VariableDigit.BusyConvert.ToDecValue("16"),			100),

				//0.00023 / 0.00032112 = 0.7162431489785749875***
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00023"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00032112"),	100),

				//12345.12345 / 0.00032112 = 38443956.93198804185351***
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("12345.12345"),		BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00032112"),	100),

				//0.00023 / 12345.12345 = 0.0000000186308383979748699***
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00023"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("12345.12345"),	100),

				//12345.12345 / 1234.1234 = 10.003151589217091256***
				BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.BusyConvert.ToDecValue("12345.12345"),		BlueBack.VariableDigit.BusyConvert.ToDecValue("1234.1234"),		100),

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

