

/** TestScene.Multiply
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE) && false
namespace TestScene.Multiply
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
				//0.0123 x 0.0156
				BlueBack.VariableDigit.BusyMultiply.Multiply(new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,23}),new BlueBack.VariableDigit.DecValue(1,-1,new int[]{4,56})),

				//0.0123 x 0
				BlueBack.VariableDigit.BusyMultiply.Multiply(new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,2,3}),BlueBack.VariableDigit.DecValue.zero),

				//0 x 0.0123
				BlueBack.VariableDigit.BusyMultiply.Multiply(BlueBack.VariableDigit.DecValue.zero,new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,2,3})),
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

