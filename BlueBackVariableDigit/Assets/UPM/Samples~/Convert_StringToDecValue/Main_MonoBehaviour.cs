

/** BlueBack.VariableDigit.Samples.Convert_StringToDecValue
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Convert_StringToDecValue
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : InspectorViewer_MonoBehaviour
	{
		/** decvalue
		*/
		public System.Collections.Generic.List<DecValue> decvalue;

		/** Awake
		*/
		private void Awake()
		{
			this.decvalue = new System.Collections.Generic.List<DecValue>(){

				BusyConvert.ToDecValue("0"),

				BusyConvert.ToDecValue("0.1"),
				BusyConvert.ToDecValue("0.01"),
				BusyConvert.ToDecValue("0.001"),
				BusyConvert.ToDecValue("0.0001"),
				BusyConvert.ToDecValue("0.00001"),

				BusyConvert.ToDecValue("-0.1"),
				BusyConvert.ToDecValue("-0.01"),
				BusyConvert.ToDecValue("-0.001"),
				BusyConvert.ToDecValue("-0.0001"),
				BusyConvert.ToDecValue("-0.00001"),

				BusyConvert.ToDecValue("1"),
				BusyConvert.ToDecValue("10"),
				BusyConvert.ToDecValue("100"),
				BusyConvert.ToDecValue("1000"),
				BusyConvert.ToDecValue("10000"),
				BusyConvert.ToDecValue("100000"),

				BusyConvert.ToDecValue("-1"),
				BusyConvert.ToDecValue("-10"),
				BusyConvert.ToDecValue("-100"),
				BusyConvert.ToDecValue("-1000"),
				BusyConvert.ToDecValue("-10000"),
				BusyConvert.ToDecValue("-100000"),

				BusyConvert.ToDecValue("1.1"),
				BusyConvert.ToDecValue("10.01"),
				BusyConvert.ToDecValue("100.001"),
				BusyConvert.ToDecValue("1000.0001"),
				BusyConvert.ToDecValue("10000.00001"),

				BusyConvert.ToDecValue("-1.1"),
				BusyConvert.ToDecValue("-10.01"),
				BusyConvert.ToDecValue("-100.001"),
				BusyConvert.ToDecValue("-1000.0001"),
				BusyConvert.ToDecValue("-10000.00001"),

				BusyConvert.ToDecValue("12345678.12345678"),
				BusyConvert.ToDecValue("-12345678.12345678"),

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

