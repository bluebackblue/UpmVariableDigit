

/** TestScene.Addition
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
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
				//0 + 0
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.DecValue.zero,BlueBack.VariableDigit.DecValue.zero),

				//+ 0 + 0.0123
				BlueBack.VariableDigit.BusyAddition.Addition(BlueBack.VariableDigit.DecValue.zero, new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,23})),

				//+ 0.0123 + 0
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,23}),BlueBack.VariableDigit.DecValue.zero),

				//+ 0.0123 + 0.000567
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(1,-1,new int[]{1,23}),new BlueBack.VariableDigit.DecValue(1,-2,new int[]{5,67})),

				//- 0.0123 - 0.000567
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(-1,-1,new int[]{1,23}),new BlueBack.VariableDigit.DecValue(-1,-2,new int[]{5,67})),

				//+ 1234 + 0.000567
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(1,1,new int[]{12,34}),new BlueBack.VariableDigit.DecValue(1,-2,new int[]{5,67})),

				//+ 9 + 8
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(1,0,new int[]{9}),new BlueBack.VariableDigit.DecValue(1,0,new int[]{8})),

				//+ 10000 - 1
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(1,2,new int[]{1}),new BlueBack.VariableDigit.DecValue(-1,0,new int[]{1})),

				//- 10000 + 1
				BlueBack.VariableDigit.BusyAddition.Addition(new BlueBack.VariableDigit.DecValue(-1,2,new int[]{1}),new BlueBack.VariableDigit.DecValue(1,0,new int[]{1})),
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

