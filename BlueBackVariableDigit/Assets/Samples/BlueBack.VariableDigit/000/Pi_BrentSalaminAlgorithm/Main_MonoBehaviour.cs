

/** BlueBack.VariableDigit.Samples.Pi_BrentSalaminAlgorithm
*/
#if(!DEF_BLUEBACK_VARIABLEDIGIT_SAMPLES_DISABLE)
namespace BlueBack.VariableDigit.Samples.Pi_BrentSalaminAlgorithm
{
	/** Main_MonoBehaviour

		AGM

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
			this.decvalue = new System.Collections.Generic.List<DecValue>(){null};
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
			DecValue t_sqrt_2 = BusySqrt.Sqrt(DecValue.value_2,111,99);

			UnityEngine.Debug.Log(string.Format("sqrt(2) = {0}",BusyConvert.ToString(t_sqrt_2,20)));
			yield return null;

			DecValue t_a = DecValue.value_1;
			DecValue t_b = BusyDivision.Division(DecValue.value_1,t_sqrt_2,111 * 3);
			DecValue t_t = DecValue.value_4_inverse;
			DecValue t_p = DecValue.value_1;

			for(int nn=0;nn<15;nn++){
				//(a + b) * 0.5;
				DecValue t_new_a;
				{
					t_new_a = BusyAddition.Addition(t_a,t_b);
					t_new_a = BusyMultiply.Multiply(t_new_a,DecValue.value_2_inverse);
				}

				yield return null;

				//sqrt(a * b);
				DecValue t_new_b;
				{
					t_new_b = BusyMultiply.Multiply(t_a,t_b);
					t_new_b = BusySqrt.Sqrt(t_new_b,111,77);
				}

				yield return null;

				//t - p * pow(a - new_a,2)
				DecValue t_new_t;
				{
					t_new_t = BusySubtraction.Subtraction(t_a,t_new_a);
					t_new_t = BusyMultiply.Multiply(t_new_t,t_new_t);
					t_new_t = BusyMultiply.Multiply(t_new_t,t_p);
					t_new_t = BusySubtraction.Subtraction(t_t,t_new_t);
				}

				yield return null;

				//p * 2;
				DecValue t_new_p;
				{
					t_new_p = BusyMultiply.Multiply(t_p,DecValue.value_2);
				}

				yield return null;

				t_a = t_new_a;
				t_b = t_new_b;
				t_t = t_new_t;
				t_p = t_new_p;

				t_a.CutMantissa(111);
				t_b.CutMantissa(111);
				t_t.CutMantissa(111);
				t_p.CutMantissa(111);

				{
					DecValue t_result = BusyAddition.Addition(t_a,t_b);
					t_result = BusyMultiply.Multiply(t_result,t_result);
					t_result = BusyMultiply.Multiply(t_result,DecValue.value_4_inverse);
					t_result = BusyDivision.Division(t_result,t_t,1000);

					{
						System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();
						{
							t_stringbuilder.Append("\npi = ");
							BusyConvert.AddToStringBuilder(t_result,t_stringbuilder,100);
						}

						UnityEngine.Debug.Log(string.Format("{0}:{1}",nn,t_stringbuilder));
						yield return null;
					}
				}
			}

			yield break;
		}
	}
}
#endif

