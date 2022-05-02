

/** TestScene.Subtraction
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE) && false
namespace TestScene.Subtraction
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : BlueBack.VariableDigit.InspectorViewer_MonoBehaviour
	{
		/** decvalue
		*/
		public BlueBack.VariableDigit.DecValue[] decvalue;

		/** Start
		*/
		private void Start()
		{
			//decvalue
			this.decvalue = new BlueBack.VariableDigit.DecValue[]{
				//0 - 0
				BlueBack.VariableDigit.BusySubtraction.Subtraction(BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),BlueBack.VariableDigit.BusyConvert.ToDecValue("0")),

				//0.1 - 10.0123
				BlueBack.VariableDigit.BusySubtraction.Subtraction(BlueBack.VariableDigit.BusyConvert.ToDecValue("0.1"),BlueBack.VariableDigit.BusyConvert.ToDecValue("10.0123")),

				//10.0123 - 0.1
				BlueBack.VariableDigit.BusySubtraction.Subtraction(BlueBack.VariableDigit.BusyConvert.ToDecValue("10.0123"),BlueBack.VariableDigit.BusyConvert.ToDecValue("0.1")),
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

