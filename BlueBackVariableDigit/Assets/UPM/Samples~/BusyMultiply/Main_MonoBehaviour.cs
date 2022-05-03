

/** BlueBack.VariableDigit.Samples.BusyMultiply
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.BusyMultiply
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

				//0 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),

				//1 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("1"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * 1 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("1")),
				//-1 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("-1"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * -1 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-1")),

				//10 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("10"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * 10 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("10")),
				//-10 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("-10"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * -10 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-10")),

				//100 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("100"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * 100 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("100")),
				//-100 * 0 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("-100"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 * -100 = 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-100")),

				//99 * 88 = 8712
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("88")),
				//-99 * -88 = 8712
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("-99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-88")),
				//99 * -88 = -8712
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-88")),
				//-99 * 88 = -8712
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("-99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("88")),

				//50 * 2 = 100
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("50"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("2")),

				//3000.0003 * 200.002 = 600006.0600006
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("3000.0003"),	BlueBack.VariableDigit.BusyConvert.ToDecValue("200.002")),

				//12345678.99 * 987654.32 = 12193263187806.7368
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("12345678.99"),	BlueBack.VariableDigit.BusyConvert.ToDecValue("987654.32")),

				//0.00004567 * 0.000098 = 0.00000000447566
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00004567"),	BlueBack.VariableDigit.BusyConvert.ToDecValue("0.000098")),
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

