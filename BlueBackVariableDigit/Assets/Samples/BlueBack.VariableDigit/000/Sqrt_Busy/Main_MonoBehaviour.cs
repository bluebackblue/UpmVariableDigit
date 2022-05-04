

/** BlueBack.VariableDigit.Samples.Sqrt_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Sqrt_Busy
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** decvalue
		*/
		public System.Collections.Generic.List<DecValue> decvalue;

		/** Awake
		*/
		private void Awake()
		{
			this.decvalue = new System.Collections.Generic.List<DecValue>(){
				BusyConvert.ToDecValue("2"),
				BusyConvert.ToDecValue("3"),
				BusyConvert.ToDecValue("10"),
				BusyConvert.ToDecValue("0.0001")
			};
		}

		/** Start
		*/
		private void Start()
		{
			#if(UNITY_EDITOR)
			this.gameObject.AddComponent<InspectorViewer_MonoBehaviour>().decvalue = this.decvalue;
			#endif

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}
		
		/** CoroutineMain

			ニュートンラフソン法で[sqrt(2)]を求める。

		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			for(int ii=0;ii<this.decvalue.Count;ii++){
				t_stringbuilder.Clear();
				BlueBack.VariableDigit.BusyConvert.AddToStringBuilder(this.decvalue[ii],t_stringbuilder,1000);
				UnityEngine.Debug.Log(string.Format("{0}",t_stringbuilder));
			}

			yield break;
		}
	}
}
#endif

