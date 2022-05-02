

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
			BlueBack.VariableDigit.DecValue t_epsilon_1075 = BlueBack.VariableDigit.BusyConvert.ToDecValue(double.Epsilon);
			for(int ii=0;ii<1075;ii++){
				t_epsilon_1075 = BlueBack.VariableDigit.BusyMultiply.Multiply(t_epsilon_1075,BlueBack.VariableDigit.DecValue.two);
			}

			//decvalue
			this.decvalue = new BlueBack.VariableDigit.DecValue[]{
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-0.1234567"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1.234567"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-12.34567"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-123.4567"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1234.567"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-12345.67"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-123456.7"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-1234567.0"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("0"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.1"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.01"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.0001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.00001"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.000001"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue("0.99999"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("99999.99999"),
				BlueBack.VariableDigit.BusyConvert.ToDecValue("-99999.99999"),

				BlueBack.VariableDigit.BusyConvert.ToDecValue(0),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(1000.0001d),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(234),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(-567),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(0.001d),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(0.99999d),
				BlueBack.VariableDigit.BusyConvert.ToDecValue(-99999.99999d),

				BlueBack.VariableDigit.DecValue.zero,
				BlueBack.VariableDigit.DecValue.one,
				BlueBack.VariableDigit.DecValue.two,
				BlueBack.VariableDigit.DecValue.half,

				BlueBack.VariableDigit.BusyConvert.ToDecValue(double.Epsilon),
				t_epsilon_1075,
			};

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}

		/** CoroutineMain
		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			for(int ii=0;ii<this.decvalue.Length;ii++){
				UnityEngine.Debug.Log(string.Format("{0:0.################}",BlueBack.VariableDigit.BusyConvert.ToDouble(this.decvalue[ii],1000)));
			}

			yield break;
		}
	}
}
#endif

