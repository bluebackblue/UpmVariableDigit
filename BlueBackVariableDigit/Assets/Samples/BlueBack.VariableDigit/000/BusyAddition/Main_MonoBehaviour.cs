

/** BlueBack.VariableDigit.Samples.BusyAddition
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.BusyAddition
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
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),

				//1 + 0 = 1
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("1"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + 1 = 1
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("1")),
				//-1 + 0 = -1
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-1"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + -1 = -1
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-1")),

				//10 + 0 = 10
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("10"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + 10 = 10
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("10")),
				//-10 + 0 = -10
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-10"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + -10 = -10
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-10")),

				//100 + 0 = 100
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("100"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + 100 = 100
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("100")),
				//-100 + 0 = -100
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-100"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),
				//0 + -100 = -100
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-100")),

				//99 + 88 = 187
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("88")),
				//-99 + -88 = -187
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-88")),
				//99 + -88 = 11
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("-88")),
				//-99 + 88 = -11
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-99"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("88")),

				//9999 + 1 = 10000
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("9999"),			BlueBack.VariableDigit.BusyConvert.ToDecValue("1")),

				//10000 + -1 = 9999
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("10000"),		BlueBack.VariableDigit.BusyConvert.ToDecValue("-1")),
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

