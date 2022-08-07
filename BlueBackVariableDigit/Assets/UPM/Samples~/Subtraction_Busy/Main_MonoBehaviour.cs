

/** BlueBack.VariableDigit.Samples.Subtraction_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Subtraction_Busy
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : InspectorViewer_MonoBehaviour
	{
		/** decvalue
		*/
		public System.Collections.Generic.List<DecValue> decvalue;

		/** Awake
		*/
		private void Awake()
		{
			this.decvalue = new System.Collections.Generic.List<DecValue>(){

				//0 - 0 = 0
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("0")),

				//1 - 0 = 1
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("1"),			BusyConvert.ToDecValue("0")),
				//0 - 1 = -1
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("1")),
				//-1 - 0 = -1
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("-1"),			BusyConvert.ToDecValue("0")),
				//0 - -1 = 1
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("-1")),

				//0.125 - 0 = 0.125
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0.125"),		BusyConvert.ToDecValue("0")),
				//0 - 0.125 = -0.125
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("0.125")),
				//-0.125 - 0 = -0.125
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("-0.125"),		BusyConvert.ToDecValue("0")),
				//0 - -0.125 = 0.125
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("-0.125")),

				//100 - 0 = 100
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("100"),			BusyConvert.ToDecValue("0")),
				//0 - 100 = -100
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("100")),
				//-100 - 0 = -100
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("-100"),			BusyConvert.ToDecValue("0")),
				//0 - -100 = 100
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("-100")),

				//99 - 88 = 11
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("99"),			BusyConvert.ToDecValue("88")),
				//-99 - -88 = -11
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("-99"),			BusyConvert.ToDecValue("-88")),
				//99 - -88 = 187
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("99"),			BusyConvert.ToDecValue("-88")),
				//-99 - 88 = -187
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("-99"),			BusyConvert.ToDecValue("88")),

				//10000 - 1 = 9999
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("10000"),		BusyConvert.ToDecValue("1")),

				//9999 - -1 = 10000
				BusySubtraction.Subtraction(BusyConvert.ToDecValue("9999"),			BusyConvert.ToDecValue("-1")),
			};
		}

		/** Start
		*/
		private void Start()
		{
			#if(UNITY_EDITOR)
			this.editor_view_list = this.decvalue;
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
				t_stringbuilder.Clear();
				BusyConvert.AddToStringBuilder(this.decvalue[ii],t_stringbuilder,1000);
				UnityEngine.Debug.Log(string.Format("{0}",t_stringbuilder));
			}

			yield break;
		}
	}
}
#endif

