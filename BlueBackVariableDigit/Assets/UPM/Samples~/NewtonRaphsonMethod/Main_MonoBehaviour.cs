

/** BlueBack.VariableDigit.Samples.NewtonRaphsonMethod
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.NewtonRaphsonMethod
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
			this.decvalue = new System.Collections.Generic.List<DecValue>(){null};
		}

		/** Start
		*/
		private void Start()
		{
			#if(UNITY_EDITOR)
			this.gameObject.AddComponent<BlueBack.VariableDigit.InspectorViewer_MonoBehaviour>().decvalue = this.decvalue;
			#endif

			//CoroutineMain
			this.StartCoroutine(this.CoroutineMain());
		}
		
		/** CoroutineMain

			ニュートンラフソン法で[1 / 987654321]を求める。

		*/
		private System.Collections.IEnumerator CoroutineMain()
		{
			BlueBack.VariableDigit.DecValue t_value = BlueBack.VariableDigit.BusyConvert.ToDecValue("987654321");

			//初期値。
			BlueBack.VariableDigit.DecValue t_value_inv = BlueBack.VariableDigit.DecValue.value_1;

			for(int ii=0;ii<20;ii++){
				{
					UnityEngine.Debug.Log(string.Format("count : {0}",ii));
				}

				//vxn = V * X(n)
				BlueBack.VariableDigit.DecValue t_vxn = BlueBack.VariableDigit.BusyMultiply.Multiply(t_value,t_value_inv);

				{
					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
					BlueBack.VariableDigit.BusyConvert.ToStringBuilderWithLimit(t_vxn,t_stringbuilder,50);
					UnityEngine.Debug.Log(string.Format("vxn = {0} : exponent = {1}",t_stringbuilder,t_vxn.exponent));
					yield return null;
				}

				if(t_vxn.exponent >= 0){
					t_value_inv = BlueBack.VariableDigit.BusyMultiply.Multiply(t_value_inv,BlueBack.VariableDigit.DecValue.value_16_inverse);
					continue;
				}

				//2_vxn = 2 - (V * X(n))
				BlueBack.VariableDigit.DecValue t_2_vxn = BlueBack.VariableDigit.BusySubtraction.Subtraction(BlueBack.VariableDigit.DecValue.value_2,t_vxn);

				//X(n+1) = N(n) * (2 - (V * X(n)))
				t_value_inv = BlueBack.VariableDigit.BusyMultiply.Multiply(t_value_inv,t_2_vxn);

				{
					t_value_inv.CutMantissa(100);
					this.decvalue[0] = t_value_inv;

					System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
					BlueBack.VariableDigit.BusyConvert.ToStringBuilderWithLimit(t_value_inv,t_stringbuilder,1000);
					UnityEngine.Debug.Log(string.Format("value_inv = {0}",t_stringbuilder));
					yield return null;
				}
			}

			{
				t_value_inv = BlueBack.VariableDigit.BusyDivision.DivisionWithLimit(BlueBack.VariableDigit.DecValue.value_1,t_value,100);
				System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder(1024);
				BlueBack.VariableDigit.BusyConvert.ToStringBuilderWithLimit(t_value_inv,t_stringbuilder,1000);
				UnityEngine.Debug.Log(string.Format("BusyDivision : value_inv = {0}",t_stringbuilder));
				yield return null;
			}

			yield break;
		}
	}
}
#endif

