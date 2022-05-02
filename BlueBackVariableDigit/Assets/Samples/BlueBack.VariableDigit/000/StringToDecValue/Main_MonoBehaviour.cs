

/** TestScene.StringToDecValue
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace TestScene.StringToDecValue
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

				BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.01"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00001"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.01"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.0001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.00001"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("10"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("100"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("1000"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("10000"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("100000"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-10"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-100"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1000"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-10000"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-100000"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("1.1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("10.01"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("100.001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("1000.0001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("10000.00001"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1.1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-10.01"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-100.001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1000.0001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-10000.00001"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("12345678.12345678"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-12345678.12345678"),
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

