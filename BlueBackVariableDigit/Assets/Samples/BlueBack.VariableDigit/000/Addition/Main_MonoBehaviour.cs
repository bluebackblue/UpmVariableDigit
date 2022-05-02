

/** TestScene.Addition
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE) && false
namespace TestScene.Addition
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
				//+ 0 + 0 = 0
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.DecValue.zero,BlueBack.VariableDigit.DecValue.zero),

				//+ 0 + 0.0123 = 0.0123
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.DecValue.zero,BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0123")),

				//+ 0.0123 + 0 = 0.0123
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0123"),BlueBack.VariableDigit.DecValue.zero),

				//+ 0.0123 + 0.000567 = 0.012867
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0123"),BlueBack.VariableDigit.BusyConvert.ToDecValue("0.000567")),

				//- 0.0123 - 0.000567 = - 0.012867
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.0123"),BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.000567")),

				//+ 1234 + 0.000567 = 1234.000567
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("1234"),BlueBack.VariableDigit.BusyConvert.ToDecValue("0.000567")),

				//+ 9 + 8 = 17
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("9"),BlueBack.VariableDigit.BusyConvert.ToDecValue("8")),

				//+ 10000 - 1 = 9999
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("10000"),BlueBack.VariableDigit.BusyConvert.ToDecValue("-1")),

				//- 10000 + 1 = - 9999
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.BusyConvert.ToDecValue("-10000"),BlueBack.VariableDigit.BusyConvert.ToDecValue("1")),
			};

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
			for(int ii=0;ii<this.decvalue.Length;ii++){
				BlueBack.VariableDigit.BusyConvert.ToStringBuilder(this.decvalue[ii],t_stringbuilder);
				UnityEngine.Debug.Log(t_stringbuilder.ToString());
			}

			yield break;
		}
	}
}
#endif

