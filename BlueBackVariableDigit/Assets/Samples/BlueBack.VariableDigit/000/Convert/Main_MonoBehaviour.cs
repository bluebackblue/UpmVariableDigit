

/** TestScene.Convert
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace TestScene.Convert
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : BlueBack.VariableDigit.InspectorViewer_MonoBehaviour
	{
		/** decvalue
		*/
		public BlueBack.VariableDigit.DecValue[] decvalue;

		/** [BlueBack.VariableDigit.InspectorViewer_MonoBehaviour]表示物の取得。
		*/
		#if(UNITY_EDITOR)
		public override BlueBack.VariableDigit.DecValue[] GetMultiDecValue()
		{
			return this.decvalue;
		}
		#endif

		/** Start
		*/
		private void Start()
		{
			//decvalue
			this.decvalue = new BlueBack.VariableDigit.DecValue[]{
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0123"),

				/*
				BlueBack.VariableDigit.BusyConvert.ToDecValue(0),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(12),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(987),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(-321),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(0.01f),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(0.99999f),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(-99999.99999f),
				*/
			};

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			for(int ii=0;ii<this.decvalue.Length;ii++){
				UnityEngine.Debug.Log(string.Format("{0}",BlueBack.VariableDigit.BusyConvert.ToDouble(this.decvalue[ii],1000)));
			}

			yield break;
		}
	}
}
#endif

