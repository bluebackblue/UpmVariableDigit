

/** BlueBack.VariableDigit.Samples.Addition_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Addition_Busy
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
				BusyAddition.Addition(BusyConvert.ToDecValue("0"),			BusyConvert.ToDecValue("0")),

				BusyAddition.Addition(BusyConvert.ToDecValue("12345.321"),	BusyConvert.ToDecValue("-12345.321")),
				BusyAddition.Addition(BusyConvert.ToDecValue("-12345.321"),	BusyConvert.ToDecValue("12345.321")),

				//1290
				BusyAddition.Addition(BusyConvert.ToDecValue("1234"),		BusyConvert.ToDecValue("56")),
				//-1290
				BusyAddition.Addition(BusyConvert.ToDecValue("-1234"),		BusyConvert.ToDecValue("-56")),
				//1178
				BusyAddition.Addition(BusyConvert.ToDecValue("1234"),		BusyConvert.ToDecValue("-56")),
				//-1178
				BusyAddition.Addition(BusyConvert.ToDecValue("-1234"),		BusyConvert.ToDecValue("56")),
				//1290
				BusyAddition.Addition(BusyConvert.ToDecValue("56"),			BusyConvert.ToDecValue("1234")),
				//-1290
				BusyAddition.Addition(BusyConvert.ToDecValue("-56"),		BusyConvert.ToDecValue("-1234")),
				//-1178
				BusyAddition.Addition(BusyConvert.ToDecValue("56"),			BusyConvert.ToDecValue("-1234")),
				//1178
				BusyAddition.Addition(BusyConvert.ToDecValue("-56"),		BusyConvert.ToDecValue("1234")),

				//10000
				BusyAddition.Addition(BusyConvert.ToDecValue("9999"),		BusyConvert.ToDecValue("1")),

				//9999
				BusyAddition.Addition(BusyConvert.ToDecValue("10000"),		BusyConvert.ToDecValue("-1")),

				//0.0021
				BusyAddition.Addition(BusyConvert.ToDecValue("0.0001"),		BusyConvert.ToDecValue("0.002")),
				//98765.0021
				BusyAddition.Addition(BusyConvert.ToDecValue("0.0001"),		BusyConvert.ToDecValue("98765.002")),
				//-0.0019
				BusyAddition.Addition(BusyConvert.ToDecValue("0.0001"),		BusyConvert.ToDecValue("-0.002")),
				//-98765.0019
				BusyAddition.Addition(BusyConvert.ToDecValue("0.0001"),		BusyConvert.ToDecValue("-98765.002")),
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

