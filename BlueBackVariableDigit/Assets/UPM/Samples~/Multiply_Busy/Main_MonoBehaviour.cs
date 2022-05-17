

/** BlueBack.VariableDigit.Samples.Multiply_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Multiply_Busy
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

				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("0")),

				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("1"),				BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("1")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("-1"),				BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("-1")),

				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("10"),				BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("10")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("-10"),			BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("-10")),

				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("100"),			BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("100")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("-100"),			BusyConvert.ToDecValue("0")),
				//0
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0"),				BusyConvert.ToDecValue("-100")),

				//8712
				BusyMultiply.Multiply(BusyConvert.ToDecValue("99"),				BusyConvert.ToDecValue("88")),
				//8712
				BusyMultiply.Multiply(BusyConvert.ToDecValue("-99"),			BusyConvert.ToDecValue("-88")),
				//-8712
				BusyMultiply.Multiply(BusyConvert.ToDecValue("99"),				BusyConvert.ToDecValue("-88")),
				//-8712
				BusyMultiply.Multiply(BusyConvert.ToDecValue("-99"),			BusyConvert.ToDecValue("88")),

				//100
				BusyMultiply.Multiply(BusyConvert.ToDecValue("50"),				BusyConvert.ToDecValue("2")),

				//600006.0600006
				BusyMultiply.Multiply(BusyConvert.ToDecValue("3000.0003"),		BusyConvert.ToDecValue("200.002")),

				//12193263187806.7368
				BusyMultiply.Multiply(BusyConvert.ToDecValue("12345678.99"),	BusyConvert.ToDecValue("987654.32")),

				//0.00000000447566
				BusyMultiply.Multiply(BusyConvert.ToDecValue("0.00004567"),		BusyConvert.ToDecValue("0.000098")),
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

