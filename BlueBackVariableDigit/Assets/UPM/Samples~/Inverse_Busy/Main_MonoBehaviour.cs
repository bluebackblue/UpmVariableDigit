

/** BlueBack.VariableDigit.Samples.Inverse_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Inverse_Busy
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
			
				//0.00000000101249999998734375000015820312499802246
				BusyInverse.Inverse(BusyConvert.ToDecValue("987654321"),100,100),
			
				//0.0999999999999999999999999999999999999999
				BusyInverse.Inverse(BusyConvert.ToDecValue("10"),100,100),

				//0.0999999999999999999999999999999999999999
				BusyInverse.Inverse(BusyConvert.ToDecValue("2"),100,100),

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

