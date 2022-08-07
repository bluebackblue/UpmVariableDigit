

/** Samples.Division_Busy
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Division_Busy
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

				//0.0625
				BusyDivision.Division(BusyConvert.ToDecValue("1"),					BusyConvert.ToDecValue("16"),				100),

				//0.7162431489785749875***
				BusyDivision.Division(BusyConvert.ToDecValue("0.00023"),			BusyConvert.ToDecValue("0.00032112"),		100),

				//38443956.931988041853***
				BusyDivision.Division(BusyConvert.ToDecValue("12345.12345"),		BusyConvert.ToDecValue("0.00032112"),		100),

				//0.0000000186308383979***
				BusyDivision.Division(BusyConvert.ToDecValue("0.00023"),			BusyConvert.ToDecValue("12345.12345"),		100),

				//10.003151589217091256***
				BusyDivision.Division(BusyConvert.ToDecValue("12345.12345"),		BusyConvert.ToDecValue("1234.1234"),		100),

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

